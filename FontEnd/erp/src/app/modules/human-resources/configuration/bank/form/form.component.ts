import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { BankService } from '../bank.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { BankViewModel } from '../bank.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';

@Component({
  selector: 'app-hr-bank-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class BankFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  form: FormGroup;
  item: BankViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    public translate: TranslateService,
    private elm: ElementRef,
    private dialogRef: MatDialogRef<BankFormComponent>,
    private fb: FormBuilder,
    private bankService: BankService) {
    }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.BANK.FORM.TITLE_NEW';
    this.permission = this.bankService.getPermission();
    this.form = this.fb.group({
      id: [0],
      code: ['', [Validators.required, Validators.maxLength(10)]],
      name: ['', [Validators.required, Validators.maxLength(100)]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });
    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.BANK.FORM.TITLE_EDIT';
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
    this.form.get('id').setValue(0);
    this.form.get('code').reset();
    this.form.get('name').reset();
    this.form.get('precedence').reset();
    this.form.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.form.get('code').disable();
      this.form.get('name').disable();
      this.form.get('precedence').disable();
      this.form.get('isActive').disable();
    } else {
      this.form.get('name').enable();
      this.form.get('precedence').enable();
      this.form.get('isActive').enable();
      this.form.get('precedence').setValue(1);
      this.form.get('isActive').setValue(true);

      if (formStatus === FormActionStatus.Insert) {
        this.elm.nativeElement.querySelector('#code').focus();
        this.form.get('code').enable();
      } else {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }
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

  onSubmitForm() {
    this.isSubmit = true;
    if (this.form.invalid) {
      return;
    }
    this.isLoading = true;

    this.bankService.save(this.form.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.bankService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: BankViewModel) {
    this.form.get('id').setValue(data.id);
    this.form.get('code').setValue(data.code);
    this.form.get('name').setValue(data.name);
    this.form.get('precedence').setValue(data.precedence);
    this.form.get('isActive').setValue(data.isActive);
    this.form.get('rowVersion').setValue(data.rowVersion);
  }
}
