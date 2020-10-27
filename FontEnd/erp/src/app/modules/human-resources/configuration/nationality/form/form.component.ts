
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { NationalityService } from './../nationality.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { NationalityViewModel } from './../nationality.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-nationality-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class NationalityFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  nationalityForm: FormGroup;
  item: NationalityViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<NationalityFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private nationalityService: NationalityService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.NATIONALITY.FORM.TITLE_NEW';
    this.permission = this.nationalityService.getPermission();
    this.nationalityForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.NATIONALITY.FORM.TITLE_EDIT';
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
    this.nationalityForm.get('id').setValue(0);
    this.nationalityForm.get('name').reset();
    this.nationalityForm.get('precedence').reset();
    this.nationalityForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.nationalityForm.get('name').disable();
      this.nationalityForm.get('precedence').disable();
      this.nationalityForm.get('isActive').disable();
    } else {
      this.nationalityForm.get('isActive').setValue(true);
      this.nationalityForm.get('precedence').setValue(1);
      this.nationalityForm.get('name').enable();
      this.nationalityForm.get('precedence').enable();
      this.nationalityForm.get('isActive').enable();
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
    if (this.nationalityForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.nationalityService.save(this.nationalityForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.nationalityService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: NationalityViewModel) {
    this.nationalityForm.get('id').setValue(data.id);
    this.nationalityForm.get('name').setValue(data.name);
    this.nationalityForm.get('precedence').setValue(data.precedence);
    this.nationalityForm.get('isActive').setValue(data.isActive);
    this.nationalityForm.get('rowVersion').setValue(data.rowVersion);
  }

}
