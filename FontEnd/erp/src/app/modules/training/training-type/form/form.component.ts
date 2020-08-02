import { AppValidator } from 'src/app/core/validators/app.validator';
import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { TrainingTypeService } from '../training-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { TrainingTypeViewModel } from '../training-type.model';

@Component({
  selector: 'app-training-training-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class TrainingTypeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  trainingTypeForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private trainingTypeService: TrainingTypeService) { }

  ngOnInit(): void {
    this.trainingTypeForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [AppValidator.number]],
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
    this.trainingTypeForm.get('id').setValue(0);
    this.trainingTypeForm.get('name').reset();
    this.trainingTypeForm.get('description').reset();
    this.trainingTypeForm.get('precedence').reset();
    this.trainingTypeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.trainingTypeForm.get('name').disable();
      this.trainingTypeForm.get('description').disable();
      this.trainingTypeForm.get('precedence').disable();
      this.trainingTypeForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.trainingTypeForm.get('isActive').setValue(true);
    this.trainingTypeForm.get('precedence').setValue(1);
      this.trainingTypeForm.get('name').enable();
      this.trainingTypeForm.get('description').enable();
      this.trainingTypeForm.get('precedence').enable();
      this.trainingTypeForm.get('isActive').enable();
	  this.elm.nativeElement.querySelector('#name').focus();
    }
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
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
    if (this.trainingTypeForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.trainingTypeForm.getRawValue() as TrainingTypeViewModel;
    model.action = this.formAction;

    this.trainingTypeService.save(model).subscribe((res: ResponseModel) => {
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
    this.trainingTypeService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.trainingTypeForm.get('id').setValue(response.result.id);
        this.trainingTypeForm.get('name').setValue(response.result.name);
        this.trainingTypeForm.get('description').setValue(response.result.description);
        this.trainingTypeForm.get('precedence').setValue(response.result.precedence);
        this.trainingTypeForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
