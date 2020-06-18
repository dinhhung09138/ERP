import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { Router, ActivatedRoute } from '@angular/router';
import { DateValidator } from 'src/app/core/validators/date.validator';

@Component({
  selector: 'app-hr-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  employeeForm: FormGroup;
  isLoading = false;
  isSubmit = false;
  panelTitle = '';

  formAction = FormActionStatus.UnKnow;
  isEditEmployee = false;

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
    private router: Router,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.checkFormAction();
    this.panelTitle = 'Create New Employee';
    this.employeeForm = this.fb.group({
      id: [null],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      workingEmail: ['', [Validators.required, Validators.email]],
      workingPhone: [''],
      badgeCardNumber: [''],
      dateApplyBadge: [null, [DateValidator.date]],
      fingerSignNumber: ['', [Validators.required]],
      dateApplyFingerSign: [null, [DateValidator.date]],
      probationDate: [null, [DateValidator.date]],
      startWorkingDate: [null, [DateValidator.date]],
      employeeWorkingStatusId: [null, [Validators.required]],
      basicSalary: [null]
    });
  }

  initFormControl() {

  }

  checkFormAction() {
    console.log(this.router.url);
    if (this.router.url.indexOf('/employee/new') > 0) {
      this.formAction = FormActionStatus.Create;
    } else if (this.router.url.indexOf('/employee/edit/') > 0) {
      this.formAction = FormActionStatus.Update;
    }
  }

  edit() {
    this.isEditEmployee = true;
  }

  cancel() {

  }

  reset() {

  }

  close() {
    this.router.navigate(['/hr/employee']);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.employeeForm.invalid) {
      this.isSubmit = false;
      return;
    }
    this.isLoading = true;
  }

}
