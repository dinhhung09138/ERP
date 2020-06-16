import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ModelOfStudyService } from '../model-of-study.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ModelOfStudyViewModel } from '../model-of-study.model';

@Component({
  selector: 'app-hr-model-of-study-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ModelOfStudyFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  modelOfStudyForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private modelOfStudyService: ModelOfStudyService) { }

  ngOnInit(): void {
    this.modelOfStudyForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.modelOfStudyForm.get('id').setValue(0);
    this.modelOfStudyForm.get('name').reset();
    this.modelOfStudyForm.get('precedence').reset();
    this.modelOfStudyForm.get('isActive').reset();

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.modelOfStudyForm.get('name').disable();
        this.modelOfStudyForm.get('precedence').disable();
        this.modelOfStudyForm.get('isActive').disable();
      } else {
        this.modelOfStudyForm.get('isActive').setValue(true);
        this.modelOfStudyForm.get('precedence').setValue(1);
        this.modelOfStudyForm.get('name').enable();
        this.modelOfStudyForm.get('precedence').enable();
        this.modelOfStudyForm.get('isActive').enable();
      }
    }
  }

  create() {
    this.initFormControl(FormActionStatus.Create);
  }

  update(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  reset() {
    this.initFormControl(this.formAction, false);
  }

  close() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.modelOfStudyForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.modelOfStudyForm.value as ModelOfStudyViewModel;
    model.action = this.formAction;

    this.modelOfStudyService.save(model).subscribe((res: ResponseModel) => {
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
    this.modelOfStudyService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.modelOfStudyForm.get('id').setValue(response.result.id);
        this.modelOfStudyForm.get('name').setValue(response.result.name);
        this.modelOfStudyForm.get('precedence').setValue(response.result.precedence);
        this.modelOfStudyForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
