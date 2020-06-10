import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { CommendationViewModel } from '../commendation.model';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  commendationForm: FormGroup;

  constructor(private fb: FormBuilder, private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.commendationForm = this.fb.group({
      name: ['', [Validators.required]],
      description: [''],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {

    this.formAction = formStatus;
    this.commendationForm.get('name').reset();
    this.commendationForm.get('description').reset();
    this.commendationForm.get('isActive').setValue(true);

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.commendationForm.get('name').disable();
        this.commendationForm.get('description').disable();
        this.commendationForm.get('isActive').disable();
      } else {
        console.log('enable');
        this.commendationForm.get('name').enable();
        this.commendationForm.get('description').enable();
        this.commendationForm.get('isActive').enable();
      }
    }
  }

  create() {
    this.initFormControl(FormActionStatus.Create);
  }

  reset() {
    this.initFormControl(this.formAction, false);
  }

  close() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    this.isLoading = true;
    if (this.commendationForm.invalid) {
      return;
    }
    const model = this.commendationForm.value as CommendationViewModel;
    model.action = this.formAction;
    console.log(model);
    this.commendationService.save(model).subscribe((res: ResponseModel) => {
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

}
