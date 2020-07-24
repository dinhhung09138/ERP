import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IdentificationTypeService } from '../identification-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { IdentificationTypeViewModel } from '../identification-type.model';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-identification-type-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class IdentificationTypeFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  identificationForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private identificationService: IdentificationTypeService) { }

  ngOnInit(): void {
    this.identificationForm = this.fb.group({
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
    this.identificationForm.get('id').setValue(0);
    this.identificationForm.get('name').reset();
    this.identificationForm.get('isActive').reset();
    this.identificationForm.get('precedence').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.identificationForm.get('name').disable();
      this.identificationForm.get('precedence').disable();
      this.identificationForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.identificationForm.get('isActive').setValue(true);
      this.identificationForm.get('precedence').setValue(1);
      this.identificationForm.get('name').enable();
      this.identificationForm.get('precedence').enable();
      this.identificationForm.get('isActive').enable();
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
    if (this.identificationForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.identificationForm.value as IdentificationTypeViewModel;
    model.action = this.formAction;

    this.identificationService.save(model).subscribe((res: ResponseModel) => {
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
    this.identificationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.identificationForm.get('id').setValue(response.result.id);
        this.identificationForm.get('name').setValue(response.result.name);
        this.identificationForm.get('precedence').setValue(response.result.precedence);
        this.identificationForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
