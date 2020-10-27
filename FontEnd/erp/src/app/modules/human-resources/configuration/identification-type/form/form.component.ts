import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { IdentificationTypeService } from '../identification-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { IdentificationTypeViewModel } from '../identification-type.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-identification-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class IdentificationTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  identificationForm: FormGroup;
  item: IdentificationTypeViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<IdentificationTypeFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private identificationService: IdentificationTypeService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.IDENTIFICATION.FORM.TITLE_NEW';
    this.permission = this.identificationService.getPermission();
    this.identificationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.IDENTIFICATION.FORM.TITLE_EDIT';
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
    this.identificationForm.get('id').setValue(0);
    this.identificationForm.get('name').reset();
    this.identificationForm.get('isActive').reset();
    this.identificationForm.get('precedence').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.identificationForm.get('name').disable();
      this.identificationForm.get('precedence').disable();
      this.identificationForm.get('isActive').disable();
    } else {
      this.identificationForm.get('isActive').setValue(true);
      this.identificationForm.get('precedence').setValue(1);
      this.identificationForm.get('name').enable();
      this.identificationForm.get('precedence').enable();
      this.identificationForm.get('isActive').enable();
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
    if (this.identificationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.identificationService.save(this.identificationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.identificationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: IdentificationTypeViewModel) {
    this.identificationForm.get('id').setValue(data.id);
    this.identificationForm.get('name').setValue(data.name);
    this.identificationForm.get('precedence').setValue(data.precedence);
    this.identificationForm.get('isActive').setValue(data.isActive);
    this.identificationForm.get('rowVersion').setValue(data.rowVersion);
  }
}
