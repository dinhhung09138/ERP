import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { IdentificationTypeService } from '../identification-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { IdentificationTypeViewModel } from '../identification-type.model';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-identification-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class IdentificationTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  identificationForm: FormGroup;
  item: IdentificationTypeViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private identificationService: IdentificationTypeService) { }

  ngOnInit(): void {
    this.identificationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
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
    this.identificationForm.get('id').setValue(0);
    this.identificationForm.get('name').reset();
    this.identificationForm.get('isActive').reset();
    this.identificationForm.get('precedence').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.identificationForm.get('name').disable();
      this.identificationForm.get('precedence').disable();
      this.identificationForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.identificationForm.get('isActive').setValue(true);
      this.identificationForm.get('precedence').setValue(1);
      this.identificationForm.get('name').enable();
      this.identificationForm.get('precedence').enable();
      this.identificationForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
    this.formTitle = 'Thêm mới';
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.formTitle = 'Cập nhật';
  }

  onResetClick() {
    switch(this.formAction) {
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
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.identificationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.identificationService.save(this.identificationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.identificationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: IdentificationTypeViewModel) {
    this.identificationForm.get('id').setValue(data.id);
    this.identificationForm.get('name').setValue(data.name);
    this.identificationForm.get('precedence').setValue(data.precedence);
    this.identificationForm.get('isActive').setValue(data.isActive);
  }
}
