import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { CommendationService } from '../commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { CommendationViewModel } from '../commendation.model';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class CommendationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  commendationForm: FormGroup;
  item: CommendationViewModel;

  constructor(
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private formatNumber: FormatNumberPipe,
    private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.commendationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      money: ['0', [Validators.required, AppValidator.money]],
      isActive: [true],
      rowVersion: [null],
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
    } else {
      this.commendationForm.get('isActive').setValue(true);
      this.commendationForm.get('money').setValue(0);
      this.commendationForm.get('name').enable();
      this.commendationForm.get('description').enable();
      this.commendationForm.get('money').enable();
      this.commendationForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
    this.translate.get('SCREEN.HR.COMMENDATION.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.COMMENDATION.FORM.TITLE_EDIT').subscribe(message => {
      this.formTitle = message;
    });
  }

  onResetClick() {
    switch(this.formAction) {
      case FormActionStatus.Insert:
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
    if (this.commendationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.commendationService.save(this.commendationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.commendationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: CommendationViewModel) {
    this.commendationForm.get('id').setValue(data.id);
    this.commendationForm.get('name').setValue(data.name);
    this.commendationForm.get('description').setValue(data.description);
    this.commendationForm.get('money').setValue(this.formatNumber.transform(data.money));
    this.commendationForm.get('isActive').setValue(data.isActive);
    this.commendationForm.get('rowVersion').setValue(data.rowVersion);
  }
}
