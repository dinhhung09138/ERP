import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { ModelOfStudyService } from '../model-of-study.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ModelOfStudyViewModel } from '../model-of-study.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-model-of-study-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class ModelOfStudyFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  modelOfStudyForm: FormGroup;
  item: ModelOfStudyViewModel;

  constructor(
    public translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<ModelOfStudyFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private modelOfStudyService: ModelOfStudyService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.MODEL_OF_STUDY.FORM.TITLE_NEW';
    this.permission = this.modelOfStudyService.getPermission();
    this.modelOfStudyForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.MODEL_OF_STUDY.FORM.TITLE_EDIT';
        this.initFormControl(FormActionStatus.Update);
        this.getItem(this.dialogData.itemId);
      }
    }
    this.translate.get(title).subscribe(message => {
      this.formTitle = message;
    });
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.modelOfStudyForm.get('id').setValue(0);
    this.modelOfStudyForm.get('name').reset();
    this.modelOfStudyForm.get('precedence').reset();
    this.modelOfStudyForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.modelOfStudyForm.get('name').disable();
      this.modelOfStudyForm.get('precedence').disable();
      this.modelOfStudyForm.get('isActive').disable();
    } else {
      this.modelOfStudyForm.get('isActive').setValue(true);
      this.modelOfStudyForm.get('precedence').setValue(1);
      this.modelOfStudyForm.get('name').enable();
      this.modelOfStudyForm.get('precedence').enable();
      this.modelOfStudyForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
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
    this.dialogRef.close(false);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.modelOfStudyForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.modelOfStudyService.save(this.modelOfStudyForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.modelOfStudyService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ModelOfStudyViewModel) {
    this.modelOfStudyForm.get('id').setValue(data.id);
    this.modelOfStudyForm.get('name').setValue(data.name);
    this.modelOfStudyForm.get('precedence').setValue(data.precedence);
    this.modelOfStudyForm.get('isActive').setValue(data.isActive);
    this.modelOfStudyForm.get('rowVersion').setValue(data.rowVersion);
  }
}
