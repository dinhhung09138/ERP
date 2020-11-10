import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { RelationshipTypeService } from '../relationship-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RelationshipTypeViewModel } from '../relationship-type.model';
import { AppValidator } from './../../../../../core/validators/app.validator';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-relationship-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class RelationshipTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  relationshipTypeForm: FormGroup;
  item: RelationshipTypeViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<RelationshipTypeFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private relationshipTypeService: RelationshipTypeService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.RELATIONSHIP_TYPE.FORM.TITLE_NEW';
    this.permission = this.relationshipTypeService.getPermission();
    this.relationshipTypeForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.RELATIONSHIP_TYPE.FORM.TITLE_EDIT';
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
    this.relationshipTypeForm.get('id').setValue(0);
    this.relationshipTypeForm.get('name').reset();
    this.relationshipTypeForm.get('description').reset();
    this.relationshipTypeForm.get('precedence').reset();
    this.relationshipTypeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.relationshipTypeForm.get('name').disable();
      this.relationshipTypeForm.get('description').disable();
      this.relationshipTypeForm.get('precedence').disable();
      this.relationshipTypeForm.get('isActive').disable();
    } else {
      this.relationshipTypeForm.get('precedence').setValue(1);
      this.relationshipTypeForm.get('isActive').setValue(true);
      this.relationshipTypeForm.get('name').enable();
      this.relationshipTypeForm.get('description').enable();
      this.relationshipTypeForm.get('precedence').enable();
      this.relationshipTypeForm.get('isActive').enable();

      this.elm.nativeElement.querySelector('#name').focus();
    }
  }

  onResetClick() {
    switch (this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.elm.nativeElement.querySelector('#name').focus();
        break;
    }
  }

  onCloseClick() {
    this.dialogRef.close(false);
  }

  onSubmitForm() {
    this.isSubmit = true;
    if (this.relationshipTypeForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.relationshipTypeService.save(this.relationshipTypeForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.relationshipTypeService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: RelationshipTypeViewModel) {
    this.relationshipTypeForm.get('id').setValue(data.id);
    this.relationshipTypeForm.get('name').setValue(data.name);
    this.relationshipTypeForm.get('description').setValue(data.description);
    this.relationshipTypeForm.get('precedence').setValue(data.precedence);
    this.relationshipTypeForm.get('isActive').setValue(data.isActive);
    this.relationshipTypeForm.get('rowVersion').setValue(data.rowVersion);
  }
}
