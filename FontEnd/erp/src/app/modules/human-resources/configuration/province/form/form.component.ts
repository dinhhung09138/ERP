import { Component, OnInit, Output, EventEmitter, ElementRef, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { ProvinceService } from '../province.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProvinceViewModel } from '../province.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-province-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class ProvinceFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  provinceForm: FormGroup;
  item: ProvinceViewModel;

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<ProvinceFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private provinceService: ProvinceService) { }

  ngOnInit(): void {
    this.permission = this.provinceService.getPermission();
    this.provinceForm = this.fb.group({
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

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.provinceForm.get('id').setValue(0);
    this.provinceForm.get('name').reset();
    this.provinceForm.get('precedence').reset();
    this.provinceForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.provinceForm.get('name').disable();
      this.provinceForm.get('precedence').disable();
      this.provinceForm.get('isActive').disable();
    } else {
      this.provinceForm.get('isActive').setValue(true);
      this.provinceForm.get('precedence').setValue(1);
      this.provinceForm.get('name').enable();
      this.provinceForm.get('precedence').enable();
      this.provinceForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
    this.translate.get('SCREEN.HR.CONFIGURATION.PROVINCE.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.PROVINCE.FORM.TITLE_EDIT').subscribe(message => {
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
    if (!this.permission.allowInsert && !this.permission.allowUpdate) {
      return;
    }

    this.isSubmit = true;
    if (this.provinceForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.provinceService.save(this.provinceForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.provinceService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
       this.item = response.result;
       this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: ProvinceViewModel) {
    this.provinceForm.get('id').setValue(data.id);
    this.provinceForm.get('name').setValue(data.name);
    this.provinceForm.get('precedence').setValue(data.precedence);
    this.provinceForm.get('isActive').setValue(data.isActive);
    this.provinceForm.get('rowVersion').setValue(data.rowVersion);
  }

}
