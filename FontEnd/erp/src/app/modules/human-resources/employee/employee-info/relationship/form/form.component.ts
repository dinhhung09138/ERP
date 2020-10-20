import { Component, OnInit, ViewChild, ElementRef, Inject } from '@angular/core';
import { FormGroupDirective, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeRelationShipService } from '../relationship.service';
import { RelationshipTypeService } from '../../../../configuration/relationship-type/relationship-type.service';
import { RelationshipTypeViewModel } from '../../../../configuration/relationship-type/relationship-type.model';
import { ResponseModel } from '../../../../../../core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EmployeeRelationShipViewModel } from '../relationship.model';
import { AppValidator } from '../../../../../../core/validators/app.validator';
import { FormActionStatus } from '../../../../../../core/enums/form-action-status.enum';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-employee-relationship-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EmployeeRelationshipFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, { static: true}) formDirective: FormGroupDirective;

  formTitle = '';
  isLoading = false;
  isSubmit = false;
  employeeId = 0;
  form: FormGroup;
  formAction: FormActionStatus;
  listRelationShip: RelationshipTypeViewModel[];
  item: EmployeeRelationShipViewModel;

  constructor(
    private elm: ElementRef,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EmployeeRelationshipFormComponent>,
    private fb: FormBuilder,
    private emplRelationShipService: EmployeeRelationShipService,
  ) { }

  ngOnInit(): void {

    this.form = this.fb.group({
      id: [0],
      employeeId: [null, Validators.required],
      fullName: ['', [Validators.required]],
      address: ['', [Validators.maxLength(255)]],
      mobile: ['', [Validators.maxLength(20)]],
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
    this.form.get('address').reset();
    this.form.get('mobile').reset();
    this.form.get('relationshipTypeId').setValue('');
    this.form.get('isActive').reset();

    if (formAction === FormActionStatus.UnKnow) {
      this.form.get('fullName').disable();
      this.form.get('address').disable();
      this.form.get('mobile').disable();
      this.form.get('relationshipTypeId').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('isActive').setValue(true);
      this.form.get('fullName').enable();
      this.form.get('address').enable();
      this.form.get('mobile').enable();
      this.form.get('relationshipTypeId').enable();
      this.form.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#fullName').focus();
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
    this.emplRelationShipService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.dialogRef.close(true);
      }
    });
  }

  private getItem(itemId: number) {
    this.isLoading = true;
    this.emplRelationShipService.item(itemId).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.setDataToForm(response.result);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EmployeeRelationShipViewModel) {
    if (data) {
      this.form.get('id').setValue(data.id);
      this.form.get('employeeId').setValue(this.employeeId);
      this.form.get('fullName').setValue(data.fullName);
      this.form.get('address').setValue(data.address);
      this.form.get('mobile').setValue(data.mobile);
      this.form.get('relationshipTypeId').setValue(data.relationshipTypeId);
      this.form.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
