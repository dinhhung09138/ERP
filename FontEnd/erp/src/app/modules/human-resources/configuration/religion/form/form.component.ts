import { ReligionService } from './../religion.service';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { Validators, FormBuilder, FormGroup, FormGroupDirective } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ReligionViewModel } from './../religion.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Component, OnInit, ElementRef, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-hr-religion-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class ReligionFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  religionForm: FormGroup;
  item: ReligionViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<ReligionFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private religionService: ReligionService) { }

  ngOnInit(): void {
    this.religionForm = this.fb.group({
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

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.religionForm.get('id').setValue(0);
    this.religionForm.get('name').reset();
    this.religionForm.get('precedence').reset();
    this.religionForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.religionForm.get('name').disable();
      this.religionForm.get('precedence').disable();
      this.religionForm.get('isActive').disable();
    } else {
      this.religionForm.get('isActive').setValue(true);
      this.religionForm.get('precedence').setValue(1);
      this.religionForm.get('name').enable();
      this.religionForm.get('precedence').enable();
      this.religionForm.get('isActive').enable();
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
    this.translate.get('SCREEN.HR.CONFIGURATION.RELIGION.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.RELIGION.FORM.TITLE_EDIT').subscribe(message => {
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
    if (this.religionForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.religionForm.value as ReligionViewModel;
    model.action = this.formAction;

    this.religionService.save(this.religionForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.religionService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {

        if (this.dialogData?.isPopup === true) {
          this.dialogRef.close(true);
        }

        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ReligionViewModel) {
    this.religionForm.get('id').setValue(data.id);
    this.religionForm.get('name').setValue(data.name);
    this.religionForm.get('precedence').setValue(data.precedence);
    this.religionForm.get('isActive').setValue(data.isActive);
    this.religionForm.get('rowVersion').setValue(data.rowVersion);
  }

}
