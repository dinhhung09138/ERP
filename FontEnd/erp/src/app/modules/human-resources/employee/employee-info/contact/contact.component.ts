import { Component, OnInit, Input, ViewChild, OnChanges, SimpleChanges, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { EmployeeContactViewModel } from './contact.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { EmployeeViewModel } from '../../employee.model';
import { ProvinceViewModel } from '../../../configuration/province/province.model';
import { EmployeeContactService } from './contact.service';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { ResponseModel } from '../../../../../core/models/response.model';

@Component({
  selector: 'app-hr-employee-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class EmployeeContactComponent implements OnInit, OnChanges {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Input() employee: EmployeeViewModel;

  permission = new PermissionViewModel();
  isEdit = false; // If true, enable control for editing
  isLoading = false;
  isSubmit = false;
  contactInfo: EmployeeContactViewModel;
  form: FormGroup;

  ethnicityLoading = false;
  listProvince: ProvinceViewModel[] = [];

  constructor(
    private employeeContactService: EmployeeContactService,
    private fb: FormBuilder,
    private elementRef: ElementRef
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeContactService.getPermission();
    this.form = this.fb.group({
      id: [0],
      employeeId: [0],
      phone: ['', [Validators.maxLength(15)]],
      mobile: ['', [Validators.maxLength(15)]],
      email: ['', [Validators.maxLength(100)]],
      skype: ['', [Validators.maxLength(50)]],
      zalo: ['', [Validators.maxLength(20)]],
      facebook: ['', [Validators.maxLength(200)]],
      linkedIn: ['', [Validators.maxLength(200)]],
      twitter: ['', [Validators.maxLength(200)]],
      github: ['', [Validators.maxLength(200)]],
      temporaryAddress: ['', [Validators.maxLength(250)]],
      temporaryProvinceId: [''],
      permanentAddress: ['', [Validators.maxLength(250)]],
      permanentProvinceId: [''],
      rowVersion: [null],
    });
    this.initFormControl();
  }

  ngOnChanges(data: SimpleChanges) {
    if (data.employee && data.employee.currentValue) {
      this.form.get('employeeId').setValue(data.employee.currentValue.id);
      this.getInfoByEmployeeId(data.employee.currentValue.id);
    }
  }

  initFormControl() {

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.form.get('id').setValue(0);
    this.form.get('employeeId').setValue(null);
    this.form.get('phone').setValue('');
    this.form.get('mobile').setValue('');
    this.form.get('email').setValue('');
    this.form.get('skype').setValue('');
    this.form.get('zalo').setValue('');
    this.form.get('facebook').setValue('');
    this.form.get('linkedIn').setValue('');
    this.form.get('twitter').setValue('');
    this.form.get('github').setValue('');
    this.form.get('temporaryAddress').setValue('');
    this.form.get('temporaryProvinceId').setValue('');
    this.form.get('permanentAddress').setValue('');
    this.form.get('permanentProvinceId').setValue('');

  }

  onEditClick() {
    this.isEdit = true;
    this.elementRef.nativeElement.querySelector('#phone').focus();
  }

  onCancelClick() {
    this.isEdit = false;
    this.initFormControl();
    this.setDataToForm(this.contactInfo);
  }

  onResetClick() {
    this.initFormControl();
    this.setDataToForm(this.contactInfo);
  }

  private getInfoByEmployeeId(employeeId: number) {
    if (this.employee) {
      this.isLoading = true;
      this.employeeContactService.getInfoByEmployeeId(employeeId).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.contactInfo = response.result;
          this.setDataToForm(this.contactInfo);
        }
        this.isLoading = false;
      });
    }
  }

  onSubmit() {

    this.isSubmit = true;

    if (this.form.invalid) {
      this.isSubmit = false;
      return;
    }
    this.isLoading = true;
    this.employeeContactService.save(this.form.getRawValue()).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.contactInfo = response.result;
        this.setDataToForm(response.result);
        this.isEdit = false;
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  public getSelection() {
    this.isLoading = true;
    this.employeeContactService.getSelection().subscribe(response => {
      if (response.provinces && response.provinces.responseStatus === ResponseStatus.success) {
        this.listProvince = response.provinces.result;
      }

      this.isLoading = false;
    });
  }

  private setDataToForm(data?: EmployeeContactViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employee.id);
      this.form.get('phone').setValue(data.phone);
      this.form.get('mobile').setValue(data.mobile);
      this.form.get('email').setValue(data.email);
      this.form.get('skype').setValue(data.skype);
      this.form.get('zalo').setValue(data.zalo);
      this.form.get('facebook').setValue(data.facebook);
      this.form.get('linkedIn').setValue(data.linkedIn);
      this.form.get('twitter').setValue(data.twitter);
      this.form.get('github').setValue(data.github);
      this.form.get('temporaryAddress').setValue(data.phone);
      this.form.get('temporaryProvinceId').setValue(data.temporaryProvinceId || '');
      this.form.get('permanentAddress').setValue(data.permanentAddress);
      this.form.get('permanentProvinceId').setValue(data.permanentProvinceId || '');
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
