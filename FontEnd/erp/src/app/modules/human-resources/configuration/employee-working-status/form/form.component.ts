import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { EmployeeWorkingStatusViewModel } from '../employee-working-status.model';
import { EmployeeWorkingStatusService } from '../employee-working-status.service';

@Component({
  selector: 'app-hr-employee-working-status-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeWorkingStatusFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  workingStatusForm: FormGroup;
  item: EmployeeWorkingStatusViewModel;

  constructor(
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private workingStatusService: EmployeeWorkingStatusService
  ) { }

  ngOnInit(): void {
    this.workingStatusForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.workingStatusForm.get('id').setValue(0);
    this.workingStatusForm.get('code').reset();
    this.workingStatusForm.get('name').reset();
    this.workingStatusForm.get('description').reset();
    this.workingStatusForm.get('isActive').reset();
    this.workingStatusForm.get('precedence').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.workingStatusForm.get('code').disable();
      this.workingStatusForm.get('name').disable();
      this.workingStatusForm.get('description').disable();
      this.workingStatusForm.get('isActive').disable();
      this.workingStatusForm.get('precedence').disable();
    } else {
      this.workingStatusForm.get('isActive').setValue(true);
      this.workingStatusForm.get('precedence').setValue(1);
      this.workingStatusForm.get('name').enable();
      this.workingStatusForm.get('description').enable();
      this.workingStatusForm.get('isActive').enable();
      this.workingStatusForm.get('precedence').enable();

      if (formStatus === FormActionStatus.Insert) {
        this.workingStatusForm.get('code').enable();
        this.elm.nativeElement.querySelector('#code').focus();
      } else {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#code').focus();
    this.translate.get('SCREEN.HR.CONFIGURATION.WORKING_STATUS.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.WORKING_STATUS.FORM.TITLE_EDIT').subscribe(message => {
      this.formTitle = message;
    });
  }

  onResetClick() {
    switch (this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.elm.nativeElement.querySelector('#code').focus();
        break;
    }
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.workingStatusForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.workingStatusService.save(this.workingStatusForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.workingStatusService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeWorkingStatusViewModel) {
    this.workingStatusForm.get('id').setValue(data.id);
    this.workingStatusForm.get('code').setValue(data.code);
    this.workingStatusForm.get('name').setValue(data.name);
    this.workingStatusForm.get('description').setValue(data.description);
    this.workingStatusForm.get('precedence').setValue(data.precedence);
    this.workingStatusForm.get('isActive').setValue(data.isActive);
    this.workingStatusForm.get('rowVersion').setValue(data.rowVersion);
  }

}
