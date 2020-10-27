import { Component, OnInit, ElementRef, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { EducationService } from '../education.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EducationViewModel } from '../education.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-education-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EducationFormComponent implements OnInit {

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  educationForm: FormGroup;
  item: EducationViewModel;

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EducationFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private educationService: EducationService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.EDUCATION.FORM.TITLE_NEW';
    this.permission = this.educationService.getPermission();
    this.educationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.EDUCATION.FORM.TITLE_EDIT';
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

    this.formAction = formStatus;
    this.educationForm.get('id').setValue(0);
    this.educationForm.get('name').reset();
    this.educationForm.get('precedence').reset();
    this.educationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.educationForm.get('name').disable();
      this.educationForm.get('precedence').disable();
      this.educationForm.get('isActive').disable();
    } else {
      this.educationForm.get('isActive').setValue(true);
      this.educationForm.get('precedence').setValue(1);
      this.educationForm.get('name').enable();
      this.educationForm.get('precedence').enable();
      this.educationForm.get('isActive').enable();
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
    if (this.educationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.educationService.save(this.educationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.educationService.item(id).subscribe((response: ResponseModel) => {
      if (response  && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EducationViewModel) {
    this.educationForm.get('id').setValue(data.id);
    this.educationForm.get('name').setValue(data.name);
    this.educationForm.get('precedence').setValue(data.precedence);
    this.educationForm.get('isActive').setValue(data.isActive);
    this.educationForm.get('rowVersion').setValue(data.rowVersion);
  }

}
