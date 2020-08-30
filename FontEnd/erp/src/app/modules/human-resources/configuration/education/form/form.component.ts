import { Component, OnInit, Output, EventEmitter, ElementRef, inject, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EducationService } from '../education.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { EducationViewModel } from '../education.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-hr-education-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class EducationFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  educationForm: FormGroup;
  item: EducationViewModel;

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<EducationFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private educationService: EducationService) { }

  ngOnInit(): void {
    this.educationForm = this.fb.group({
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

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.educationForm.get('id').setValue(0);
    this.educationForm.get('name').reset();
    this.educationForm.get('precedence').reset();
    this.educationForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.educationForm.get('name').disable();
      this.educationForm.get('precedence').disable();
      this.educationForm.get('isActive').disable();
    } else {
      this.educationForm.get('isActive').setValue(true);
      this.educationForm.get('precedence').setValue(1);
      this.educationForm.get('name').enable();
      this.educationForm.get('precedence').enable();
      this.educationForm.get('isActive').enable();
    }

    this.elm.nativeElement.querySelector('#name').focus();
  }

  getClassByFormOrPopup() {
    if (this.dialogData?.isPopup === true) {
      return 'col-12';
    }
    return 'col-lg-8 col-md-12 col-sm-12 col-xs-12';
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
    this.translate.get('SCREEN.HR.CONFIGURATION.EDUCATION.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.EDUCATION.FORM.TITLE_EDIT').subscribe(message => {
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

    if (this.dialogData?.isPopup === true) {
      this.dialogRef.close(false);
    }
  }

  submitForm() {
    this.isSubmit = true;
    if (this.educationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.educationService.save(this.educationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.educationService.item(id).subscribe((response: ResponseModel) => {
      if (response  && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: EducationViewModel) {
    this.educationForm.get('id').setValue(data.id);
    this.educationForm.get('name').setValue(data.name);
    this.educationForm.get('precedence').setValue(data.precedence);
    this.educationForm.get('isActive').setValue(data.isActive);
    this.educationForm.get('rowVersion').setValue(data.rowVersion);
  }

}
