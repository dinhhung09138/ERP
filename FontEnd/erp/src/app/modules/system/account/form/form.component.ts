import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroupDirective, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { RoleViewModel } from './../../role/role.model';
import { AccountService } from './../account.service';
import { EmployeeViewModel } from '../../../human-resources/employee/employee.model';
import { FormActionStatus } from '../../../../core/enums/form-action-status.enum';

@Component({
  selector: 'app-system-account-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class AccountFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, {static: true}) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

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
  ) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(response => {
      this.listRole = response.data.role.result;
      this.listEmployee = response.data.employees.result;
      console.log(this.listRole);
      console.log(this.listEmployee);
    });
    this.accountForm = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      userName: ['', Validators.required],
      password: [null, Validators.required],
      role: [null, Validators.required],
      isActive: [true],
      rowVersion: [null]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      //this.formDirective.resetForm();
    }
    this.formAction = formStatus;
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

    //this.elm.nativeElement.querySelector('#employeeId').focus();
    this.translateService.get('SCREEN.SYSTEM.ACCOUNT.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {

  }

  onCloseClick() {

  }

  submitForm() {

  }
}
