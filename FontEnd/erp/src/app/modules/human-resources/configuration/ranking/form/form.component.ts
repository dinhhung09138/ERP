import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { RankingService } from '../ranking.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RankingViewModel } from '../ranking.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-ranking-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class RankingFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  rankingForm: FormGroup;
  item: RankingViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<RankingFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private rankingService: RankingService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.RANKING.FORM.TITLE_NEW';
    this.permission = this.rankingService.getPermission();
    this.rankingForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.RANKING.FORM.TITLE_EDIT';
        this.initFormControl(FormActionStatus.Update);
        this.getItem(this.dialogData.itemId);
      }
    }
    this.translate.get(title).subscribe(message => {
      this.formTitle = message;
    });
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.rankingForm.get('id').setValue(0);
    this.rankingForm.get('name').reset();
    this.rankingForm.get('precedence').reset();
    this.rankingForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.rankingForm.get('name').disable();
      this.rankingForm.get('precedence').disable();
      this.rankingForm.get('isActive').disable();
    } else {
      this.rankingForm.get('isActive').setValue(true);
      this.rankingForm.get('precedence').setValue(1);
      this.rankingForm.get('name').enable();
      this.rankingForm.get('precedence').enable();
      this.rankingForm.get('isActive').enable();
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
    if (this.rankingForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.rankingService.save(this.rankingForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.rankingService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: RankingViewModel) {
    this.rankingForm.get('id').setValue(data.id);
    this.rankingForm.get('name').setValue(data.name);
    this.rankingForm.get('precedence').setValue(data.precedence);
    this.rankingForm.get('isActive').setValue(data.isActive);
    this.rankingForm.get('rowVersion').setValue(data.rowVersion);
  }

}
