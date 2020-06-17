import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProfessionalQualificationService } from '../professional-qualification.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProfessionalQualificationViewModel } from '../professional-qualification.model';

@Component({
  selector: 'app-hr-professional-qualification-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ProfessionalQualificationFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  qualificationForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private qualificationService: ProfessionalQualificationService) { }

  ngOnInit(): void {
    this.qualificationForm = this.fb.group({
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
    this.qualificationForm.get('id').setValue(0);
    this.qualificationForm.get('name').reset();
    this.qualificationForm.get('precedence').reset();
    this.qualificationForm.get('isActive').reset();

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.qualificationForm.get('name').disable();
        this.qualificationForm.get('precedence').disable();
        this.qualificationForm.get('isActive').disable();
      } else {
        this.qualificationForm.get('isActive').setValue(true);
        this.qualificationForm.get('precedence').setValue(1);
        this.qualificationForm.get('name').enable();
        this.qualificationForm.get('precedence').enable();
        this.qualificationForm.get('isActive').enable();
      }
    }
    this.elm.nativeElement.querySelector('#name').focus();
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
    if (this.qualificationForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.qualificationForm.value as ProfessionalQualificationViewModel;
    model.action = this.formAction;

    this.qualificationService.save(model).subscribe((res: ResponseModel) => {
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
    this.qualificationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.qualificationForm.get('id').setValue(response.result.id);
        this.qualificationForm.get('name').setValue(response.result.name);
        this.qualificationForm.get('precedence').setValue(response.result.precedence);
        this.qualificationForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
