import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ProfessionalQualificationService } from '../professional-qualification.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProfessionalQualificationViewModel } from '../professional-qualification.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-hr-professional-qualification-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ProfessionalQualificationFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  qualificationForm: FormGroup;
  item: ProfessionalQualificationViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<ProfessionalQualificationFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private qualificationService: ProfessionalQualificationService) { }

  ngOnInit(): void {
    this.qualificationForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    if (this.dialogData && this.dialogData.isPopup === true) {
      this.formAction = FormActionStatus.Insert;
      this.translate.get(this.dialogData?.title).subscribe(message => {
        this.formTitle = message;
      });
    }

    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.qualificationForm.get('id').setValue(0);
    this.qualificationForm.get('name').reset();
    this.qualificationForm.get('precedence').reset();
    this.qualificationForm.get('isActive').reset();

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
    this.translate.get('SCREEN.HR.CONFIGURATION.QUALIFICATION.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.QUALIFICATION.FORM.TITLE_EDIT').subscribe(message => {
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
    if (this.qualificationForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.qualificationService.save(this.qualificationForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.qualificationService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ProfessionalQualificationViewModel) {
    this.qualificationForm.get('id').setValue(data.id);
    this.qualificationForm.get('name').setValue(data.name);
    this.qualificationForm.get('precedence').setValue(data.precedence);
    this.qualificationForm.get('isActive').setValue(data.isActive);
    this.qualificationForm.get('rowVersion').setValue(data.rowVersion);
  }

}
