import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { AppDateAdapter } from '../../../../../../core/helpers/format-datepicker.helper';
import { EmployeeDependencyService } from '../dependency.service';
import { RelationshipTypeViewModel } from '../../../../configuration/relationship-type/relationship-type.model';
import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EmployeeDependencyViewModel } from '../dependency.model';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { DialogDataViewModel } from '../../../../../../core/models/dialog-data.model';
import { PermissionViewModel } from '../../../../../../core/models/permission.model';
import { MAT_DATE_FORMATS, DateAdapter } from '@angular/material/core';
import { APP_DATE_FORMATS } from 'src/app/core/helpers/format-datepicker.helper';

@Component({
  selector: 'app-hr-employee-dependency-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: APP_DATE_FORMATS },
    { provide: DateAdapter, useClass: AppDateAdapter }
  ]
})
export class EmployeeDependencyFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  permission = new PermissionViewModel();
  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listRelationShip: RelationshipTypeViewModel[];

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<EmployeeDependencyFormComponent>,
    private fb: FormBuilder,
    private emplDependencyService: EmployeeDependencyService,
  ) { }

  ngOnInit(): void {
    this.permission = this.emplDependencyService.getPermission();
    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      dateOfBirth: [null, [Validators.required]],
      age: ['', [Validators.maxLength(20)]],
      relationshipTypeId: ['', [Validators.required]],
      isActive: [true],
      rowVersion: [null]
    });

    this.formAction = FormActionStatus.Insert;
    if (this.dialogData && this.dialogData.isPopup === true) {
      this.listRelationShip = this.dialogData.listRelationShip;
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
    this.form.get('fullName').reset();
    this.form.get('dateOfBirth').reset();
    this.form.get('age').reset();
    this.form.get('relationshipTypeId').setValue('');
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('fullName').disable();
      this.form.get('dateOfBirth').disable();
      this.form.get('age').disable();
      this.form.get('relationshipTypeId').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('fullName').enable();
      this.form.get('dateOfBirth').enable();
      this.form.get('age').enable();
      this.form.get('relationshipTypeId').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#relationshipTypeId').focus();
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
    this.emplDependencyService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.emplDependencyService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeDependencyViewModel) {
    if (data) {
      console.log(data);
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employeeId);
      this.form.get('fullName').setValue(data.fullName);
      this.form.get('dateOfBirth').setValue(new Date(data.dateOfBirth));
      this.form.get('age').setValue(data.age);
      this.form.get('relationshipTypeId').setValue(data.relationshipTypeId);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
