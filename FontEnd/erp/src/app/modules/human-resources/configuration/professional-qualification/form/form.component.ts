import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ProfessionalQualificationService } from '../professional-qualification.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProfessionalQualificationViewModel } from '../professional-qualification.model';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-professional-qualification-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ProfessionalQualificationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  qualificationForm: FormGroup;
  item: ProfessionalQualificationViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private qualificationService: ProfessionalQualificationService) { }

  ngOnInit(): void {
    this.qualificationForm = this.fb.group({
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
    this.qualificationForm.get('id').setValue(0);
    this.qualificationForm.get('name').reset();
    this.qualificationForm.get('precedence').reset();
    this.qualificationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.qualificationForm.get('name').disable();
      this.qualificationForm.get('precedence').disable();
      this.qualificationForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.qualificationForm.get('isActive').setValue(true);
      this.qualificationForm.get('precedence').setValue(1);
      this.qualificationForm.get('name').enable();
      this.qualificationForm.get('precedence').enable();
      this.qualificationForm.get('isActive').enable();
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
    if (this.qualificationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.qualificationService.save(this.qualificationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.qualificationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ProfessionalQualificationViewModel) {
    this.qualificationForm.get('id').setValue(data.id);
    this.qualificationForm.get('name').setValue(data.name);
    this.qualificationForm.get('precedence').setValue(data.precedence);
    this.qualificationForm.get('isActive').setValue(data.isActive);
  }

}
