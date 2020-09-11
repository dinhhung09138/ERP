import { Component, OnInit, ElementRef, EventEmitter, Output, ViewChild, Inject } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { EthnicityService } from './../ethnicity.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EthnicityViewModel } from './../ethnicity.model';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-ethnicity-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class EthnicityFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  ethnicityForm: FormGroup;
  item: EthnicityViewModel;

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EthnicityFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private ethnicityService: EthnicityService) { }

  ngOnInit(): void {
    this.ethnicityForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    if (this.dialogData?.isPopup === true) {
      this.formAction = FormActionStatus.Insert;
      this.translate.get(this.dialogData?.title).subscribe(message => {
        this.formTitle = message;
      });
    }

    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.ethnicityForm.get('id').setValue(0);
    this.ethnicityForm.get('name').reset();
    this.ethnicityForm.get('precedence').reset();
    this.ethnicityForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.ethnicityForm.get('name').disable();
      this.ethnicityForm.get('precedence').disable();
      this.ethnicityForm.get('isActive').disable();
    } else {
      this.ethnicityForm.get('isActive').setValue(true);
      this.ethnicityForm.get('precedence').setValue(1);
      this.ethnicityForm.get('name').enable();
      this.ethnicityForm.get('precedence').enable();
      this.ethnicityForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  getClassByFormOrPopup() {
    if (this.dialogData?.isPopup === true) {
      return 'col-12';
    } else {
      return 'col-lg-8 col-md-12 col-sm-12 col-xs-12';
    }
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
    this.translate.get('SCREEN.HR.CONFIGURATION.ETHNICITY.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.ETHNICITY.FORM.TITLE_EDIT').subscribe(message => {
      this.formTitle = message;
    });
  }

  onResetClick() {
    switch (this.formAction) {
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

    if (this.dialogData?.isPopup === true) {
      this.dialogRef.close(false);
    }
  }

  submitForm() {
    this.isSubmit = true;
    if (this.ethnicityForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.ethnicityService.save(this.ethnicityForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {

        if (this.dialogData?.isPopup === true) {
          this.dialogRef.close(true);
        }

        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.ethnicityService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EthnicityViewModel) {
    this.ethnicityForm.get('id').setValue(data.id);
    this.ethnicityForm.get('name').setValue(data.name);
    this.ethnicityForm.get('precedence').setValue(data.precedence);
    this.ethnicityForm.get('isActive').setValue(data.isActive);
    this.ethnicityForm.get('rowVersion').setValue(data.rowVersion);
  }

}
