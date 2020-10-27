import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { CommendationViewModel } from '../commendation.model';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class CommendationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  commendationForm: FormGroup;
  item: CommendationViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<CommendationFormComponent>,
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private formatNumber: FormatNumberPipe,
    private commendationService: CommendationService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.COMMENDATION.FORM.TITLE_NEW';
    this.permission = this.commendationService.getPermission();
    this.commendationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      money: ['0', [Validators.required, AppValidator.money]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.COMMENDATION.FORM.TITLE_EDIT';
        this.initFormControl(FormActionStatus.Update);
        this.getItem(this.dialogData.itemId);
      }
    }
    this.translate.get(title).subscribe(message => {
      this.formTitle = message;
    });
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.commendationForm.get('id').setValue(0);
    this.commendationForm.get('name').reset();
    this.commendationForm.get('description').reset();
    this.commendationForm.get('money').reset();
    this.commendationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.commendationForm.get('name').disable();
      this.commendationForm.get('description').disable();
      this.commendationForm.get('money').disable();
      this.commendationForm.get('isActive').disable();
    } else {
      this.commendationForm.get('isActive').setValue(true);
      this.commendationForm.get('money').setValue(0);
      this.commendationForm.get('name').enable();
      this.commendationForm.get('description').enable();
      this.commendationForm.get('money').enable();
      this.commendationForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onResetClick() {
    switch (this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.elm.nativeElement.querySelector('#name').focus();
        break;
    }
  }

  onCloseClick() {
    this.dialogRef.close(false);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.commendationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.commendationService.save(this.commendationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.commendationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: CommendationViewModel) {
    this.commendationForm.get('id').setValue(data.id);
    this.commendationForm.get('name').setValue(data.name);
    this.commendationForm.get('description').setValue(data.description);
    this.commendationForm.get('money').setValue(this.formatNumber.transform(data.money));
    this.commendationForm.get('isActive').setValue(data.isActive);
    this.commendationForm.get('rowVersion').setValue(data.rowVersion);
  }
}
