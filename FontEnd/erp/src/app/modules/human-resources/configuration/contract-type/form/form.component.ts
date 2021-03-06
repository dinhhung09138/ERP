import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { ContractTypeService } from '../contract-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ContractTypeViewModel } from '../contract-type.model';
import { AppValidator } from '../../../../../core/validators/app.validator';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-contract-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class ContractTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  contractTypeForm: FormGroup;
  item: ContractTypeViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<ContractTypeFormComponent>,
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private contractTypeService: ContractTypeService) {
    }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.CONTRACT_TYPE.FORM.TITLE_NEW';
    this.permission = this.contractTypeService.getPermission();
    this.contractTypeForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      allowInsurance: [true],
      allowLeaveDate: [true],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });
    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.CONTRACT_TYPE.FORM.TITLE_EDIT';
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
    this.contractTypeForm.get('id').setValue(0);
    this.contractTypeForm.get('code').reset();
    this.contractTypeForm.get('name').reset();
    this.contractTypeForm.get('description').reset();
    this.contractTypeForm.get('allowInsurance').reset();
    this.contractTypeForm.get('allowLeaveDate').reset();
    this.contractTypeForm.get('precedence').reset();
    this.contractTypeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.contractTypeForm.get('code').disable();
      this.contractTypeForm.get('name').disable();
      this.contractTypeForm.get('description').disable();
      this.contractTypeForm.get('allowInsurance').disable();
      this.contractTypeForm.get('allowLeaveDate').disable();
      this.contractTypeForm.get('precedence').disable();
      this.contractTypeForm.get('isActive').disable();
    } else {
      this.contractTypeForm.get('allowInsurance').setValue(false);
      this.contractTypeForm.get('allowLeaveDate').setValue(false);
      this.contractTypeForm.get('precedence').setValue(1);
      this.contractTypeForm.get('isActive').setValue(true);
      this.contractTypeForm.get('name').enable();
      this.contractTypeForm.get('description').enable();
      this.contractTypeForm.get('allowInsurance').enable();
      this.contractTypeForm.get('allowLeaveDate').enable();
      this.contractTypeForm.get('precedence').enable();
      this.contractTypeForm.get('isActive').enable();
      if (formStatus === FormActionStatus.Insert) {
        this.contractTypeForm.get('code').enable();
        this.elm.nativeElement.querySelector('#code').focus();
      } else {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }
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
    if (this.contractTypeForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.contractTypeService.save(this.contractTypeForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.contractTypeService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ContractTypeViewModel) {
    this.contractTypeForm.get('id').setValue(data.id);
    this.contractTypeForm.get('code').setValue(data.code);
    this.contractTypeForm.get('name').setValue(data.name);
    this.contractTypeForm.get('description').setValue(data.description);
    this.contractTypeForm.get('allowInsurance').setValue(data.allowInsurance);
    this.contractTypeForm.get('allowLeaveDate').setValue(data.allowLeaveDate);
    this.contractTypeForm.get('precedence').setValue(data.precedence);
    this.contractTypeForm.get('isActive').setValue(data.isActive);
    this.contractTypeForm.get('rowVersion').setValue(data.rowVersion);
  }
}
