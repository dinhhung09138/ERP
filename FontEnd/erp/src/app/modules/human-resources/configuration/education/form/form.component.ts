import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EducationService } from '../education.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EducationViewModel } from '../education.model';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-education-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class EducationFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  educationForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private educationService: EducationService) { }

  ngOnInit(): void {
    this.educationForm = this.fb.group({
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
    this.educationForm.get('id').setValue(0);
    this.educationForm.get('name').reset();
    this.educationForm.get('precedence').reset();
    this.educationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.educationForm.get('name').disable();
      this.educationForm.get('precedence').disable();
      this.educationForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.educationForm.get('isActive').setValue(true);
      this.educationForm.get('precedence').setValue(1);
      this.educationForm.get('name').enable();
      this.educationForm.get('precedence').enable();
      this.educationForm.get('isActive').enable();
    }

    this.elm.nativeElement.querySelector('#name').focus();
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
    if (this.educationForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.educationForm.value as EducationViewModel;
    model.action = this.formAction;

    this.educationService.save(model).subscribe((res: ResponseModel) => {
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
    this.educationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.educationForm.get('id').setValue(response.result.id);
        this.educationForm.get('name').setValue(response.result.name);
        this.educationForm.get('precedence').setValue(response.result.precedence);
        this.educationForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
