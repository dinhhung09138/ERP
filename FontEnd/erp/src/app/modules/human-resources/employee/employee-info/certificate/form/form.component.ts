import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { DialogDataViewModel } from '../../../../../../core/models/dialog-data.model';
import { PermissionViewModel } from '../../../../../../core/models/permission.model';
import { EmployeeCertificateService } from './../certificate.service';
import { CertificatedViewModel } from './../../../../configuration/certificated/certificated.model';
import { EmployeeCertificateViewModel } from './../certificate.model';
import { SchoolViewModel } from './../../../../configuration/school/school.model';
import { MajorViewModel } from './../../../../configuration/major/major.model';

@Component({
  selector: 'app-hr-employee-certificate-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeCertificateFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  permission = new PermissionViewModel();
  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listCertificated: CertificatedViewModel[];
  listSchool: SchoolViewModel[];
  listYear: number[] = [];
  item: EmployeeCertificateViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<EmployeeCertificateFormComponent>,
    private fb: FormBuilder,
    private employeeCertificateService: EmployeeCertificateService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeCertificateService.getPermission();

    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      certificateId: ['', [Validators.required]],
      schoolId: ['', [Validators.required]],
      year: ['', [Validators.required]],
      isActive: [true],
      rowVersion: [null]
    });

    const currentYear = (new Date()).getFullYear();
    for (let i = currentYear; i > currentYear - 20; i --) {
      this.listYear.push(i);
    }

    this.formAction = FormActionStatus.Insert;
    if (this.dialogData && this.dialogData.isPopup === true) {
      this.listCertificated = this.dialogData.listCertificated;
      this.listSchool = this.dialogData.listSchool;
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
    this.form.get('certificateId').setValue('');
    this.form.get('schoolId').reset();
    this.form.get('year').setValue('');
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('certificateId').disable();
      this.form.get('schoolId').disable();
      this.form.get('year').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('certificateId').enable();
      this.form.get('schoolId').enable();
      this.form.get('year').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#certificateId').focus();
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
    this.employeeCertificateService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.employeeCertificateService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeCertificateViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employeeId);
      this.form.get('certificateId').setValue(data.certificateId);
      this.form.get('schoolId').setValue(data.schoolId);
      this.form.get('year').setValue(data.year);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
