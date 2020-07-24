import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { TrainingCenterService } from './../training-center.service';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { TrainingCenterViewModel } from './../training-center.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Component, OnInit, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-training-training-center-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class TrainingCenterFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  trainingCenterForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private trainingCenterService: TrainingCenterService) { }

  ngOnInit(): void {
    this.trainingCenterForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      avatar: [''],
      phone: [''],
      taxCode: [''],
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
    this.trainingCenterForm.get('id').setValue(0);
    this.trainingCenterForm.get('avatar').reset();
    this.trainingCenterForm.get('name').reset();
    this.trainingCenterForm.get('description').reset();
    this.trainingCenterForm.get('phone').reset();
    this.trainingCenterForm.get('taxCode').reset();
    this.trainingCenterForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.trainingCenterForm.get('avatar').disable();
      this.trainingCenterForm.get('name').disable();
      this.trainingCenterForm.get('description').disable();
      this.trainingCenterForm.get('phone').disable();
      this.trainingCenterForm.get('taxCode').disable();
      this.trainingCenterForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.trainingCenterForm.get('isActive').setValue(true);
      this.trainingCenterForm.get('name').enable();
      this.trainingCenterForm.get('description').enable();
      this.trainingCenterForm.get('phone').enable();
      this.trainingCenterForm.get('taxCode').enable();
      this.trainingCenterForm.get('isActive').enable();

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

  submitForm() {
    this.isSubmit = true;
    if (this.trainingCenterForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.trainingCenterForm.getRawValue() as TrainingCenterViewModel;
    model.action = this.formAction;

    this.trainingCenterService.save(model).subscribe((res: ResponseModel) => {
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
    this.trainingCenterService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.trainingCenterForm.get('id').setValue(response.result.id);
        this.trainingCenterForm.get('avatar').setValue(response.result.avatar);
        this.trainingCenterForm.get('name').setValue(response.result.name);
        this.trainingCenterForm.get('description').setValue(response.result.description);
        this.trainingCenterForm.get('phone').setValue(response.result.phone);
        this.trainingCenterForm.get('taxCode').setValue(response.result.taxCode);
        this.trainingCenterForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
