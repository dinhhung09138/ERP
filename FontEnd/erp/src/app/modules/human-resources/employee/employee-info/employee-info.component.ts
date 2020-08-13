import { EmployeeWorkingStatusViewModel } from './../../configuration/employee-working-status/employee-working-status.model';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { Router, ActivatedRoute } from '@angular/router';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DateAdapter, MAT_DATE_FORMATS } from '@angular/material/core';
import { APP_DATE_FORMATS, AppDateAdapter } from 'src/app/core/helpers/format-datepicker.helper';
import { EmployeeService } from '../employee.service';
import { EmployeeViewModel } from '../employee.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { Title } from '@angular/platform-browser';
import { ApplicationConstant } from '../../../../core/constants/app.constant';

@Component({
  selector: 'app-hr-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: DateAdapter, useClass: AppDateAdapter }
  ]
})
export class EmployeeInfoComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  employeeForm: FormGroup;
  isLoading = false;
  isSubmit = false;
  panelTitle = '';

  formAction = FormActionStatus.UnKnow;
  isEditEmployee = false;
  currentSelectedEmployeeId = 0;
  currentSelectedEmployee: EmployeeViewModel;

  listWorkingStatus: EmployeeWorkingStatusViewModel[] = [];

  employeeTabs: any[] = [
    {
      label: 'Commendation',
      link: '/hr/employee/commendation',
      index: 0
    },
    {
      label: 'Contact',
      link: '/hr/employee/contact',
      index: 1
    },
    {
      label: 'Contract',
      link: '/hr/employee/contract',
      index: 2
    },
    {
      label: 'Dicipline',
      link: '/hr/employee/dicipline',
      index: 3
    },
    {
      label: 'Education',
      link: '/hr/employee/education',
      index: 4
    },
    {
      label: 'Identification',
      link: '/hr/employee/identification',
      index: 5
    },
    {
      label: 'Info',
      link: '/hr/employee/info',
      index: 6
    },
    {
      label: 'Relationship',
      link: '/hr/employee/relationship',
      index: 7
    },
  ];

  constructor(
    private fb: FormBuilder,
    private elm: ElementRef,
    private router: Router,
    private titleService: Title,
    private activatedRoute: ActivatedRoute,
    private formatNumber: FormatNumberPipe,
    private employeeService: EmployeeService,
  ) { }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(response => {
      this.listWorkingStatus = response.data?.workingStatusList?.result || [];
    });

    this.employeeForm = this.fb.group({
      id: [0],
      employeeCode: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      workingEmail: ['', [Validators.email]],
      workingPhone: [''],
      badgeCardNumber: [''],
      dateApplyBadge: [null, [AppValidator.date]],
      fingerSignNumber: [''],
      dateApplyFingerSign: [null, [AppValidator.date]],
      probationDate: [null, [AppValidator.date]],
      startWorkingDate: [null, [AppValidator.date]],
      employeeWorkingStatusId: [null, [Validators.required]],
      basicSalary: [0, [AppValidator.money, Validators.required]]
    });
    this.initFormControl(this.formAction);
    this.checkFormAction();
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.employeeForm.get('id').setValue(0);
    this.employeeForm.get('employeeCode').setValue('');
    this.employeeForm.get('firstName').setValue('');
    this.employeeForm.get('lastName').setValue('');
    this.employeeForm.get('workingEmail').setValue('');
    this.employeeForm.get('workingPhone').setValue('');
    this.employeeForm.get('badgeCardNumber').setValue('');
    this.employeeForm.get('dateApplyBadge').setValue(null);
    this.employeeForm.get('fingerSignNumber').setValue('');
    this.employeeForm.get('dateApplyFingerSign').setValue(null);
    this.employeeForm.get('probationDate').setValue(null);
    this.employeeForm.get('startWorkingDate').setValue(null);
    this.employeeForm.get('employeeWorkingStatusId').setValue(null);
    this.employeeForm.get('basicSalary').setValue(0);

    if (this.formAction === FormActionStatus.UnKnow) {
      this.employeeForm.get('employeeCode').disable();
      this.employeeForm.get('firstName').disable();
      this.employeeForm.get('lastName').disable();
      this.employeeForm.get('workingEmail').disable();
      this.employeeForm.get('workingPhone').disable();
      this.employeeForm.get('badgeCardNumber').disable();
      this.employeeForm.get('dateApplyBadge').disable();
      this.employeeForm.get('fingerSignNumber').disable();
      this.employeeForm.get('dateApplyFingerSign').disable();
      this.employeeForm.get('probationDate').disable();
      this.employeeForm.get('startWorkingDate').disable();
      this.employeeForm.get('employeeWorkingStatusId').disable();
      this.employeeForm.get('basicSalary').disable();
    } else {
      this.employeeForm.get('firstName').enable();
      this.employeeForm.get('lastName').enable();
      this.employeeForm.get('workingEmail').enable();
      this.employeeForm.get('workingPhone').enable();
      this.employeeForm.get('badgeCardNumber').enable();
      this.employeeForm.get('dateApplyBadge').enable();
      this.employeeForm.get('fingerSignNumber').enable();
      this.employeeForm.get('dateApplyFingerSign').enable();
      this.employeeForm.get('probationDate').enable();
      this.employeeForm.get('startWorkingDate').enable();
      this.employeeForm.get('employeeWorkingStatusId').enable();
      this.employeeForm.get('basicSalary').enable();

      if (this.formAction === FormActionStatus.Insert) {
        this.employeeForm.get('employeeCode').enable();
        this.elm.nativeElement.querySelector('#employeeCode').focus();
      } else {
        this.employeeForm.get('employeeCode').disable();
        this.elm.nativeElement.querySelector('#firstName').focus();
      }

    }
  }

  /**
   * Checking when user add new or update employee
   */
  checkFormAction() {
    if (this.router.url.indexOf('/employee/new') > 0) {
      this.initFormControl(FormActionStatus.Insert);
      this.isEditEmployee = true;
      this.setTitle();
    } else if (this.router.url.indexOf('/employee/edit/') > 0) {
      this.initFormControl(FormActionStatus.Update);
      const id = this.activatedRoute.snapshot.paramMap.get('id');
      this.currentSelectedEmployeeId = parseInt(id, 0);
      this.getEmployeeInfo(this.currentSelectedEmployeeId);
    }
  }

  onEditClick() {
    this.isEditEmployee = true;
  }

  onCancelClick() {
    this.isEditEmployee = false;
    this.initFormControl(this.formAction);
    this.setDataToFormControl(this.currentSelectedEmployee);
  }

  onResetClick() {
    this.initFormControl(this.formAction);
    this.setDataToFormControl(this.currentSelectedEmployee);
  }

  onCloseClick() {
    this.router.navigate(['/hr/employee']);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.employeeForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.employeeService.save(this.employeeForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.currentSelectedEmployee = response.result;
        this.currentSelectedEmployeeId = response.result.id;
        this.setDataToFormControl(this.currentSelectedEmployee);
        this.isEditEmployee = false;
        this.formAction = FormActionStatus.Update;
      }
      this.isSubmit = false;
      this.isLoading = false;
    });
  }

  private setTitle(name?: string) {
    if (name) {
      this.panelTitle = 'Nhân viên: ' + name;
      this.titleService.setTitle(name + ' | ' + ApplicationConstant.siteTitle);
    } else {
      this.panelTitle = 'Thên nhân viên mới';
      this.titleService.setTitle('Thên nhân viên mới' + ' | ' + ApplicationConstant.siteTitle);
    }
  }

  private getEmployeeInfo(id: number) {
    this.isLoading = true;

    this.employeeService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.currentSelectedEmployee = response.result;
        this.setDataToFormControl(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToFormControl(data?: EmployeeViewModel) {
    if (data) {
      this.setTitle(data.fullName);
      this.employeeForm.get('id').setValue(data.id);
      this.employeeForm.get('employeeCode').setValue(data.employeeCode);
      this.employeeForm.get('firstName').setValue(data.firstName);
      this.employeeForm.get('lastName').setValue(data.lastName);
      this.employeeForm.get('workingEmail').setValue(data.workingEmail);
      this.employeeForm.get('workingPhone').setValue(data.workingPhone);
      this.employeeForm.get('badgeCardNumber').setValue(data.badgeCardNumber);
      if (data.dateApplyBadge) {
        this.employeeForm.get('dateApplyBadge').setValue(new Date(data.dateApplyBadge));
      }
      this.employeeForm.get('fingerSignNumber').setValue(data.fingerSignNumber);

      if (data.dateApplyFingerSign) {
        this.employeeForm.get('dateApplyFingerSign').setValue(new Date(data.dateApplyFingerSign));
      }
      if (data.probationDate) {
        this.employeeForm.get('probationDate').setValue(new Date(data.probationDate));
      }
      if (data.startWorkingDate) {
        this.employeeForm.get('startWorkingDate').setValue(new Date(data.startWorkingDate));
      }
      this.employeeForm.get('employeeWorkingStatusId').setValue(data.employeeWorkingStatusId);
      this.employeeForm.get('basicSalary').setValue(this.formatNumber.transform(data.basicSalary));
      this.elm.nativeElement.querySelector('#firstName').focus();
    }
  }
}
