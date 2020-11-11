
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { MaritalStatusService } from './../marital-status.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { MaritalStatusViewModel } from './../marital-status.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-marital-status-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class MaritalStatusFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  form: FormGroup;
  item: MaritalStatusViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<MaritalStatusFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private maritalStatusService: MaritalStatusService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.MARITAL.FORM.TITLE_NEW';
    this.permission = this.maritalStatusService.getPermission();
    this.form = this.fb.group({
      id: [0],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.MARITAL.FORM.TITLE_EDIT';
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
    this.form.get('id').setValue(0);
    this.form.get('name').reset();
    this.form.get('precedence').reset();
    this.form.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.form.get('name').disable();
      this.form.get('precedence').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('precedence').setValue(1);
      this.form.get('name').enable();
      this.form.get('precedence').enable();
      this.form.get('isActive').enable();
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
    if (this.form.invalid) {
      return;
    }
    this.isLoading = true;

    this.maritalStatusService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.maritalStatusService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: MaritalStatusViewModel) {
    this.form.get('id').setValue(data.id);
    this.form.get('name').setValue(data.name);
    this.form.get('precedence').setValue(data.precedence);
    this.form.get('isActive').setValue(data.isActive);
    this.form.get('rowVersion').setValue(data.rowVersion);
  }

}
