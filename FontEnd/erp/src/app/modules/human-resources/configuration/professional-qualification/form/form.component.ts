import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { ProfessionalQualificationService } from '../professional-qualification.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProfessionalQualificationViewModel } from '../professional-qualification.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-professional-qualification-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class ProfessionalQualificationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  qualificationForm: FormGroup;
  item: ProfessionalQualificationViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<ProfessionalQualificationFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private qualificationService: ProfessionalQualificationService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.QUALIFICATION.FORM.TITLE_NEW';
    this.permission = this.qualificationService.getPermission();
    this.qualificationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.QUALIFICATION.FORM.TITLE_EDIT';
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
    this.qualificationForm.get('id').setValue(0);
    this.qualificationForm.get('name').reset();
    this.qualificationForm.get('precedence').reset();
    this.qualificationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.qualificationForm.get('name').disable();
      this.qualificationForm.get('precedence').disable();
      this.qualificationForm.get('isActive').disable();
    } else {
      this.qualificationForm.get('isActive').setValue(true);
      this.qualificationForm.get('precedence').setValue(1);
      this.qualificationForm.get('name').enable();
      this.qualificationForm.get('precedence').enable();
      this.qualificationForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
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
    if (this.qualificationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.qualificationService.save(this.qualificationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.qualificationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ProfessionalQualificationViewModel) {
    this.qualificationForm.get('id').setValue(data.id);
    this.qualificationForm.get('name').setValue(data.name);
    this.qualificationForm.get('precedence').setValue(data.precedence);
    this.qualificationForm.get('isActive').setValue(data.isActive);
    this.qualificationForm.get('rowVersion').setValue(data.rowVersion);
  }

}
