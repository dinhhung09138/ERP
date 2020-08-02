import { NationService } from './../nation.service';
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { NationViewModel } from './../nation.model';
import { Component, OnInit, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-hr-nation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class NationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  nationForm: FormGroup;
  item: NationViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private nationService: NationService) { }

  ngOnInit(): void {
    this.nationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.nationForm.get('id').setValue(0);
    this.nationForm.get('name').reset();
    this.nationForm.get('precedence').reset();
    this.nationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.nationForm.get('name').disable();
      this.nationForm.get('precedence').disable();
      this.nationForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.nationForm.get('isActive').setValue(true);
      this.nationForm.get('precedence').setValue(1);
      this.nationForm.get('name').enable();
      this.nationForm.get('precedence').enable();
      this.nationForm.get('isActive').enable();
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
    if (this.nationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.nationService.save(this.nationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.nationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: NationViewModel) {
    this.nationForm.get('id').setValue(data.id);
    this.nationForm.get('name').setValue(data.name);
    this.nationForm.get('precedence').setValue(data.precedence);
    this.nationForm.get('isActive').setValue(data.isActive);
  }

}
