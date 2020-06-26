import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ContractTypeService } from '../contract-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ContractTypeViewModel } from '../contract-type.model';

@Component({
  selector: 'app-hr-contract-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ContractTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  contractTypeForm: FormGroup;

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
    this.contractTypeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.contractTypeForm.get('code').disable();
      this.contractTypeForm.get('name').disable();
      this.contractTypeForm.get('description').disable();
      this.contractTypeForm.get('allowInsurance').disable();
      this.contractTypeForm.get('allowLeaveDate').disable();
      this.contractTypeForm.get('isActive').disable();
    } else {
      this.contractTypeForm.get('isActive').setValue(true);
      this.contractTypeForm.get('name').enable();
      this.contractTypeForm.get('description').enable();
      this.contractTypeForm.get('allowInsurance').enable();
      this.contractTypeForm.get('allowLeaveDate').enable();
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

  submitForm() {
    this.isSubmit = true;
    if (this.contractTypeForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.contractTypeForm.value as ContractTypeViewModel;
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
        this.contractTypeForm.get('id').setValue(response.result.id);
        this.contractTypeForm.get('code').setValue(response.result.code);
        this.contractTypeForm.get('name').setValue(response.result.name);
        this.contractTypeForm.get('description').setValue(response.result.description);
        this.contractTypeForm.get('allowInsurance').setValue(response.result.allowInsurance);
        this.contractTypeForm.get('allowLeaveDate').setValue(response.result.allowLeaveDate);
        this.contractTypeForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
