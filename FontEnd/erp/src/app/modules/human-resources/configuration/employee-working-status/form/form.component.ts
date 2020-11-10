import { Component, ElementRef, OnInit, ViewChild, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { EmployeeWorkingStatusViewModel } from '../employee-working-status.model';
import { EmployeeWorkingStatusService } from '../employee-working-status.service';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-employee-working-status-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeWorkingStatusFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  workingStatusForm: FormGroup;
  item: EmployeeWorkingStatusViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<EmployeeWorkingStatusFormComponent>,
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private workingStatusService: EmployeeWorkingStatusService
  ) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.WORKING_STATUS.FORM.TITLE_NEW';
    this.permission = this.workingStatusService.getPermission();
    this.workingStatusForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });
    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.WORKING_STATUS.FORM.TITLE_EDIT';
        this.initFormControl(FormActionStatus.Update);
        this.getItem(this.dialogData.itemId);
      }
    }
    this.translate.get(title).subscribe(message => {
      this.formTitle = message;
    });
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
    this.dialogRef.close(false);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.workingStatusForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.workingStatusService.save(this.workingStatusForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
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
