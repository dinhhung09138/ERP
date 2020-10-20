import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { EmployeeIdentificationViewModel } from '../identification.model';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { ProvinceViewModel } from '../../../../configuration/province/province.model';
import { IdentificationTypeViewModel } from '../../../../configuration/identification-type/identification-type.model';
import { DialogDataInterface } from '../../../../../../core/interfaces/dialog-data.interface';
import { EmployeeIdentificationService } from '../identification.service';
import { ResponseStatus } from '../../../../../../core/enums/response-status.enum';
import { ResponseModel } from '../../../../../../core/models/response.model';

@Component({
  selector: 'app-hr-employee-identification-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeIdentificationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listProvince: ProvinceViewModel[];
  listIdentificationType: IdentificationTypeViewModel[];
  item: EmployeeIdentificationViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EmployeeIdentificationFormComponent>,
    private fb: FormBuilder,
    private employeeIdentificationService: EmployeeIdentificationService,
  ) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      code: ['', [Validators.required, Validators.maxLength(20)]],
      placeId: ['', [Validators.required]],
      identificationTypeId: ['', [Validators.required]],
      notes: ['', [Validators.maxLength(255)]],
      expirationDate: [null],
      isActive: [true],
      rowVersion: [null]
    });

    this.formAction = FormActionStatus.Insert;
    if (this.dialogData && this.dialogData.isPopup === true) {
      this.employeeId = this.dialogData.employeeId;
      this.listProvince = this.dialogData.listProvince;
      this.listIdentificationType = this.dialogData.listIdentificationType;
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
    this.form.get('code').reset();
    this.form.get('placeId').setValue('');
    this.form.get('notes').reset();
    this.form.get('identificationTypeId').setValue('');
    this.form.get('expirationDate').reset();
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('code').disable();
      this.form.get('placeId').disable();
      this.form.get('notes').disable();
      this.form.get('identificationTypeId').disable();
      this.form.get('expirationDate').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('code').enable();
      this.form.get('placeId').enable();
      this.form.get('notes').enable();
      this.form.get('identificationTypeId').enable();
      this.form.get('expirationDate').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#identificationTypeId').focus();
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
    this.employeeIdentificationService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.employeeIdentificationService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeIdentificationViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(data.employeeId);
      this.form.get('code').setValue(data.code);
      this.form.get('placeId').setValue(data.placeId);
      this.form.get('notes').setValue(data.notes);
      this.form.get('identificationTypeId').setValue(data.identificationTypeId);
      this.form.get('expirationDate').setValue(data.expirationDate);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
