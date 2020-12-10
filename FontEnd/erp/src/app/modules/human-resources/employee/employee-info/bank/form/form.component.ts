import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { DialogDataViewModel } from '../../../../../../core/models/dialog-data.model';
import { PermissionViewModel } from '../../../../../../core/models/permission.model';
import { EmployeeBankService } from './../bank.service';
import { BankViewModel } from './../../../../configuration/bank/bank.model';
import { EmployeeBankViewModel } from './../bank.model';

@Component({
  selector: 'app-hr-employee-bank-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeBankFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  permission = new PermissionViewModel();
  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listBank: BankViewModel[];
  item: EmployeeBankViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<EmployeeBankFormComponent>,
    private fb: FormBuilder,
    private employeeBankService: EmployeeBankService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeBankService.getPermission();

    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      bankId: ['', [Validators.required]],
      bankAddress: ['', [Validators.maxLength(100)]],
      accountNumber: ['', [Validators.maxLength(100)]],
      accountOwner: ['', [Validators.maxLength(100)]],
      isActive: [true],
      rowVersion: [null]
    });

    this.formAction = FormActionStatus.Insert;
    if (this.dialogData && this.dialogData.isPopup === true) {
      this.listBank = this.dialogData.listBank;
      this.employeeId = this.dialogData.employeeId;
      this.initFormControl(this.formAction);
      if (this.dialogData.itemId !== undefined) {
        this.formAction = FormActionStatus.Update;
        this.getItem(this.dialogData.itemId);
      }
    }
  }

  initFormControl(formAction: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formAction;
    this.form.get('id').setValue(0);
    this.form.get('employeeId').setValue(this.employeeId);
    this.form.get('bankId').setValue('');
    this.form.get('bankAddress').setValue('');
    this.form.get('accountNumber').setValue('');
    this.form.get('accountOwner').setValue('');
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('bankId').disable();
      this.form.get('bankAddress').disable();
      this.form.get('accountNumber').disable();
      this.form.get('accountOwner').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('bankId').enable();
      this.form.get('bankAddress').enable();
      this.form.get('accountNumber').enable();
      this.form.get('accountOwner').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#bankId').focus();
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.dialogRef.close(false);
  }

  onSubmit() {
    this.isSubmit = true;

    if (this.form.invalid) {
      return;
    }

    this.isLoading = true;
    this.employeeBankService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.employeeBankService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeBankViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employeeId);
      this.form.get('bankId').setValue(data.bankId);
      this.form.get('bankAddress').setValue(data.bankAddress);
      this.form.get('accountNumber').setValue(data.accountNumber);
      this.form.get('accountOwner').setValue(data.accountOwner);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
