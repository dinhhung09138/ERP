import { NationalityService } from './../nationality.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { NationalityViewModel } from './../nationality.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { Component, OnInit, ElementRef, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-nationality-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class NationalityFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  nationalityForm: FormGroup;
  item: NationalityViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<NationalityFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private nationalityService: NationalityService) { }

  ngOnInit(): void {
    this.nationalityForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });

    if (this.dialogData?.isPopup === true) {
      this.formAction = FormActionStatus.Insert;
      this.formTitle = this.dialogData?.title;
    }

    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.nationalityForm.get('id').setValue(0);
    this.nationalityForm.get('name').reset();
    this.nationalityForm.get('precedence').reset();
    this.nationalityForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.nationalityForm.get('name').disable();
      this.nationalityForm.get('precedence').disable();
      this.nationalityForm.get('isActive').disable();
    } else {
      this.nationalityForm.get('isActive').setValue(true);
      this.nationalityForm.get('precedence').setValue(1);
      this.nationalityForm.get('name').enable();
      this.nationalityForm.get('precedence').enable();
      this.nationalityForm.get('isActive').enable();
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
    this.formTitle = 'Thêm mới';
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.formTitle = 'Cập nhật';
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
    if (this.nationalityForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.nationalityService.save(this.nationalityForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.nationalityService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: NationalityViewModel) {
    this.nationalityForm.get('id').setValue(data.id);
    this.nationalityForm.get('name').setValue(data.name);
    this.nationalityForm.get('precedence').setValue(data.precedence);
    this.nationalityForm.get('isActive').setValue(data.isActive);
  }

}
