import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroupDirective, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { RoleViewModel } from './../../role/role.model';
import { AccountService } from './../account.service';
import { EmployeeViewModel } from '../../../human-resources/employee/employee.model';
import { FormActionStatus } from '../../../../core/enums/form-action-status.enum';
import { ResponseModel } from '../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EmployeeService } from '../../../human-resources/employee/employee.service';

@Component({
  selector: 'app-system-account-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class AccountFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, {static: true}) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle: '';
  isLoading = false;
  isSubmit = false;

  listRole: RoleViewModel[] = [];
  listEmployee: EmployeeViewModel[] = [];

  accountForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private elm: ElementRef,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService,
    private translateService: TranslateService,
    private employeeService: EmployeeService,
  ) {
  }

  ngOnInit(): void {
    this.permission = this.accountService.getPermission();
    this.activatedRoute.data.subscribe(response => {
      this.listRole = response.data.role.result;
      this.listEmployee = response.data.employees.result;
    });
    this.accountForm = this.fb.group({
      id: [0],
      employeeId: ['', Validators.required],
      userName: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]],
      password: [null, [Validators.required, Validators.minLength(6), Validators.maxLength(50)]],
      roleId: [null, Validators.required],
      isActive: [true],
      rowVersion: [null]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.reset();
    }

    this.formAction = formStatus;
    this.accountForm.get('id').setValue(0);
    this.accountForm.get('employeeId').setValue('');
    this.accountForm.get('roleId').setValue('');

    if (formStatus === FormActionStatus.UnKnow) {
      this.accountForm.get('employeeId').disable();
      this.accountForm.get('roleId').disable();
      this.accountForm.get('userName').disable();
      this.accountForm.get('password').disable();
      this.accountForm.get('isActive').disable();
    } else {
      this.accountForm.get('isActive').setValue(true);
      this.accountForm.get('employeeId').enable();
      this.accountForm.get('roleId').enable();
      this.accountForm.get('userName').enable();
      this.accountForm.get('password').enable();
      this.accountForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#employeeId').focus();
  }

  showFormStatus(){
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }

    this.elm.nativeElement.querySelector('#employeeId').focus();
    this.translateService.get('SCREEN.SYSTEM.ACCOUNT.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {

  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;

    if (this.accountForm.invalid) {
      return;
    }
    this.accountService.insert(this.accountForm.getRawValue()).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
        this.getListEmployeeDontHaveAccount();
      }
    });
    this.isSubmit = false;
    this.isLoading = false;
  }

  private getListEmployeeDontHaveAccount() {
    this.employeeService.getEmployeeDontHaveAccount().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listEmployee = response.result;
      }
    });
  }
}
