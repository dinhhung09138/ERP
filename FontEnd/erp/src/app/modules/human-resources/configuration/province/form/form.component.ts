import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProvinceService } from '../province.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProvinceViewModel } from '../province.model';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-province-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ProvinceFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  provinceForm: FormGroup;
  item: ProvinceViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private provinceService: ProvinceService) { }

  ngOnInit(): void {
    this.provinceForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.provinceForm.get('id').setValue(0);
    this.provinceForm.get('name').reset();
    this.provinceForm.get('precedence').reset();
    this.provinceForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.provinceForm.get('name').disable();
      this.provinceForm.get('precedence').disable();
      this.provinceForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.provinceForm.get('isActive').setValue(true);
      this.provinceForm.get('precedence').setValue(1);
      this.provinceForm.get('name').enable();
      this.provinceForm.get('precedence').enable();
      this.provinceForm.get('isActive').enable();
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
    if (this.provinceForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.provinceForm.value as ProvinceViewModel;
    model.action = this.formAction;

    this.provinceService.save(model).subscribe((response: ResponseModel) => {
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
    this.provinceService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
       this.item = response.result;
       this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ProvinceViewModel) {
    this.provinceForm.get('id').setValue(data.id);
    this.provinceForm.get('name').setValue(data.name);
    this.provinceForm.get('precedence').setValue(data.precedence);
    this.provinceForm.get('isActive').setValue(data.isActive);
  }

}
