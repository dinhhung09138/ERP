import { Component, OnInit, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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
import { EmployeeWorkingStatusViewModel } from '../../employee-working-status/employee-working-status.model';

@Component({
  selector: 'app-hr-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: DateAdapter, useClass: AppDateAdapter }
  ]
})
export class EmployeeDetailComponent implements OnInit {

  employeeForm: FormGroup;
  isLoading = false;
  isSubmit = false;
  panelTitle = '';

  formAction = FormActionStatus.UnKnow;
  isEditEmployee = false;

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
    private activatedRoute: ActivatedRoute,
    private formatNumber: FormatNumberPipe,
    private employeeService: EmployeeService,
  ) { }

  ngOnInit(): void {

    this.activatedRoute.data.subscribe(response => {
      this.listWorkingStatus = response.data?.workingStatusList?.result || [];
    });

    this.panelTitle = 'Create New Employee';
    this.employeeForm = this.fb.group({
      id: [0],
      employeeCode: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      workingEmail: ['', [Validators.required, Validators.email]],
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
    this.checkFormAction();
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

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

      if (this.formAction === FormActionStatus.Create) {
        this.employeeForm.get('employeeCode').enable();
        this.elm.nativeElement.querySelector('#employeeCode').focus();
      } else {
        this.employeeForm.get('employeeCode').disable();
        this.elm.nativeElement.querySelector('#firstName').focus();
      }

    }
  }

  checkFormAction() {
    if (this.router.url.indexOf('/employee/new') > 0) {
    } else if (this.router.url.indexOf('/employee/edit/') > 0) {
      this.initFormControl(FormActionStatus.Update);
      const id = this.activatedRoute.snapshot.paramMap.get('id');
      // tslint:disable-next-line:radix
      this.getEmployeeInfo(parseInt(id));
    }
  }

  onEditClick() {
    this.isEditEmployee = true;
  }

  onCancelClick() {

  }

  onResetClick() {

  }

  onCloseClick() {
    this.router.navigate(['/hr/employee']);
  }

  submitForm() {
    console.log(this.employeeForm.getRawValue());
    this.isSubmit = true;
    if (this.employeeForm.invalid) {
      return;
    }
    this.isLoading = true;

    const model = this.employeeForm.getRawValue() as EmployeeViewModel;
    model.action = this.formAction;

    this.employeeService.save(model).subscribe((response: ResponseModel) => {
      if (response) {
        this.isLoading = false;
        this.isSubmit = false;
      }
    });

  }

  getEmployeeInfo(id: number) {
    this.isLoading = true;

    this.employeeService.item(id).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.employeeForm.get('id').setValue(response.result.id);
        this.employeeForm.get('employeeCode').setValue(response.result.employeeCode);
        this.employeeForm.get('firstName').setValue(response.result.firstName);
        this.employeeForm.get('lastName').setValue(response.result.lastName);
        this.employeeForm.get('workingEmail').setValue(response.result.workingEmail);
        this.employeeForm.get('workingPhone').setValue(response.result.workingPhone);
        this.employeeForm.get('badgeCardNumber').setValue(response.result.badgeCardNumber);
        if (response.result.dateApplyBadge) {
          this.employeeForm.get('dateApplyBadge').setValue(new Date(response.result.dateApplyBadge));
        }
        this.employeeForm.get('fingerSignNumber').setValue(response.result.fingerSignNumber);

        if (response.result.dateApplyFingerSign) {
          this.employeeForm.get('dateApplyFingerSign').setValue(new Date(response.result.dateApplyFingerSign));
        }
        if (response.result.probationDate) {
          this.employeeForm.get('probationDate').setValue(new Date(response.result.probationDate));
        }
        if (response.result.startWorkingDate) {
          this.employeeForm.get('startWorkingDate').setValue(new Date(response.result.startWorkingDate));
        }
        this.employeeForm.get('employeeWorkingStatusId').setValue(response.result.employeeWorkingStatusId);
        this.employeeForm.get('basicSalary').setValue(this.formatNumber.transform(response.result.basicSalary));
      }
      this.isLoading = false;
    });
  }

}
