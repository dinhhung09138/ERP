import { AppValidator } from './../../../../../core/validators/app.validator';
import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { RelationshipTypeService } from '../relationship-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { RelationshipTypeViewModel } from '../relationship-type.model';

@Component({
  selector: 'app-hr-relationship-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class RelationshipTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  relationshipTypeForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private relationshipTypeService: RelationshipTypeService) { }

  ngOnInit(): void {
    this.relationshipTypeForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
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
      this.isShow = false;
      this.relationshipTypeForm.get('name').disable();
      this.relationshipTypeForm.get('description').disable();
      this.relationshipTypeForm.get('precedence').disable();
      this.relationshipTypeForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.relationshipTypeForm.get('precedence').setValue(1);
      this.relationshipTypeForm.get('isActive').setValue(true);
      this.relationshipTypeForm.get('name').enable();
      this.relationshipTypeForm.get('description').enable();
      this.relationshipTypeForm.get('precedence').enable();
      this.relationshipTypeForm.get('isActive').enable();

      this.elm.nativeElement.querySelector('#name').focus();
    }

  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Create) {
      this.initFormControl(FormActionStatus.Create);
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  onSubmitForm() {
    this.isSubmit = true;
    if (this.relationshipTypeForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.relationshipTypeForm.getRawValue() as RelationshipTypeViewModel;
    model.action = this.formAction;

    this.relationshipTypeService.save(model).subscribe((res: ResponseModel) => {
      if (res !== null) {
        if (res.responseStatus === ResponseStatus.success) {
          this.initFormControl(FormActionStatus.UnKnow);
          this.reloadTableEvent.emit(true);
        }
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.relationshipTypeService.item(id).subscribe((res: ResponseModel) => {
      if (res !== null) {
        this.relationshipTypeForm.get('id').setValue(res.result.id);
        this.relationshipTypeForm.get('name').setValue(res.result.name);
        this.relationshipTypeForm.get('description').setValue(res.result.description);
        this.relationshipTypeForm.get('precedence').setValue(res.result.precedence);
        this.relationshipTypeForm.get('isActive').setValue(res.result.isActive);
      }
      this.isLoading = false;
    });
  }
}
