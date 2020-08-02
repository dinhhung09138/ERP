import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { CommendationViewModel } from '../commendation.model';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  commendationForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private formatNumber: FormatNumberPipe,
    private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.commendationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      money: ['0', [AppValidator.money]],
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
    this.commendationForm.get('id').setValue(0);
    this.commendationForm.get('name').reset();
    this.commendationForm.get('description').reset();
    this.commendationForm.get('money').reset();
    this.commendationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.commendationForm.get('name').disable();
      this.commendationForm.get('description').disable();
      this.commendationForm.get('money').disable();
      this.commendationForm.get('isActive').disable();
      this.isShow = false;
    } else {
      this.commendationForm.get('isActive').setValue(true);
      this.commendationForm.get('money').setValue(0);
      this.commendationForm.get('name').enable();
      this.commendationForm.get('description').enable();
      this.commendationForm.get('money').enable();
      this.commendationForm.get('isActive').enable();
      this.isShow = true;
    }

    this.elm.nativeElement.querySelector('#name').focus();
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
    if (this.commendationForm.invalid) {
      return;
    }
    console.log(this.commendationForm.value);
    this.isLoading = true;
    const model = this.commendationForm.value as CommendationViewModel;
    model.action = this.formAction;

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

  private getItem(id: number) {
    this.isLoading = true;
    this.commendationService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.commendationForm.get('id').setValue(response.result.id);
        this.commendationForm.get('name').setValue(response.result.name);
        this.commendationForm.get('description').setValue(response.result.description);
        this.commendationForm.get('money').setValue(this.formatNumber.transform(response.result.money));
        this.commendationForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
