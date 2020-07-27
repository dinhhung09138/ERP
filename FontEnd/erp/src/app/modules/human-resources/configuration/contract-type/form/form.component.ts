import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ContractTypeService } from '../contract-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ContractTypeViewModel } from '../contract-type.model';
import { AppValidator } from '../../../../../core/validators/app.validator';

@Component({
  selector: 'app-hr-contract-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ContractTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  contractTypeForm: FormGroup;
  item: ContractTypeViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private contractTypeService: ContractTypeService) { }

  ngOnInit(): void {
    this.contractTypeForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      allowInsurance: [true],
      allowLeaveDate: [true],
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
    this.contractTypeForm.get('id').setValue(0);
    this.contractTypeForm.get('code').reset();
    this.contractTypeForm.get('name').reset();
    this.contractTypeForm.get('description').reset();
    this.contractTypeForm.get('allowInsurance').reset();
    this.contractTypeForm.get('allowLeaveDate').reset();
    this.contractTypeForm.get('precedence').reset();
    this.contractTypeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.contractTypeForm.get('code').disable();
      this.contractTypeForm.get('name').disable();
      this.contractTypeForm.get('description').disable();
      this.contractTypeForm.get('allowInsurance').disable();
      this.contractTypeForm.get('allowLeaveDate').disable();
      this.contractTypeForm.get('precedence').disable();
      this.contractTypeForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.contractTypeForm.get('allowInsurance').setValue(false);
      this.contractTypeForm.get('allowLeaveDate').setValue(false);
      this.contractTypeForm.get('precedence').setValue(1);
      this.contractTypeForm.get('isActive').setValue(true);
      this.contractTypeForm.get('name').enable();
      this.contractTypeForm.get('description').enable();
      this.contractTypeForm.get('allowInsurance').enable();
      this.contractTypeForm.get('allowLeaveDate').enable();
      this.contractTypeForm.get('precedence').enable();
      this.contractTypeForm.get('isActive').enable();
      if (formStatus === FormActionStatus.Create) {
        this.contractTypeForm.get('code').enable();
        this.elm.nativeElement.querySelector('#code').focus();
      } else {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Create) {
      this.initFormControl(FormActionStatus.Create);
    }
    this.elm.nativeElement.querySelector('#code').focus();
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
    if (this.contractTypeForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.contractTypeForm.getRawValue() as ContractTypeViewModel;
    model.action = this.formAction;

    this.contractTypeService.save(model).subscribe((res: ResponseModel) => {
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
    this.contractTypeService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ContractTypeViewModel) {
    this.contractTypeForm.get('id').setValue(data.id);
    this.contractTypeForm.get('code').setValue(data.code);
    this.contractTypeForm.get('name').setValue(data.name);
    this.contractTypeForm.get('description').setValue(data.description);
    this.contractTypeForm.get('allowInsurance').setValue(data.allowInsurance);
    this.contractTypeForm.get('allowLeaveDate').setValue(data.allowLeaveDate);
    this.contractTypeForm.get('precedence').setValue(data.precedence);
    this.contractTypeForm.get('isActive').setValue(data.isActive);
  }
}
