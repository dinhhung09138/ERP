import { ReligionService } from './../religion.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ReligionViewModel } from './../religion.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Component, OnInit, ElementRef, Output, EventEmitter, ViewChild } from '@angular/core';

@Component({
  selector: 'app-hr-religion-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ReligionFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  rankingForm: FormGroup;
  item: ReligionViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private religionService: ReligionService) { }

  ngOnInit(): void {
    this.rankingForm = this.fb.group({
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
    this.rankingForm.get('id').setValue(0);
    this.rankingForm.get('name').reset();
    this.rankingForm.get('precedence').reset();
    this.rankingForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.rankingForm.get('name').disable();
      this.rankingForm.get('precedence').disable();
      this.rankingForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.rankingForm.get('isActive').setValue(true);
      this.rankingForm.get('precedence').setValue(1);
      this.rankingForm.get('name').enable();
      this.rankingForm.get('precedence').enable();
      this.rankingForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Create) {
      this.initFormControl(FormActionStatus.Create);
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
      case FormActionStatus.Create:
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
    if (this.rankingForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.rankingForm.value as ReligionViewModel;
    model.action = this.formAction;

    this.religionService.save(model).subscribe((response: ResponseModel) => {
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
    this.religionService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ReligionViewModel) {
    this.rankingForm.get('id').setValue(data.id);
    this.rankingForm.get('name').setValue(data.name);
    this.rankingForm.get('precedence').setValue(data.precedence);
    this.rankingForm.get('isActive').setValue(data.isActive);
  }

}
