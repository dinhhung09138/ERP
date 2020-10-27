import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { DisciplineService } from '../discipline.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DisciplineViewModel } from '../discipline.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DialogDataInterface } from '../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-discipline-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class DisciplineFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  disciplineForm: FormGroup;
  item: DisciplineViewModel;

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<DisciplineFormComponent>,
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private formatNumber: FormatNumberPipe,
    private disciplineService: DisciplineService) { }

  ngOnInit(): void {
    let title = 'SCREEN.HR.DISCIPLINE.FORM.TITLE_NEW';
    this.permission = this.disciplineService.getPermission();
    this.disciplineForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      money: [0, [Validators.required, AppValidator.money]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.DISCIPLINE.FORM.TITLE_EDIT';
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
    this.disciplineForm.get('id').setValue(0);
    this.disciplineForm.get('name').reset();
    this.disciplineForm.get('description').reset();
    this.disciplineForm.get('money').reset();
    this.disciplineForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.disciplineForm.get('name').disable();
      this.disciplineForm.get('description').disable();
      this.disciplineForm.get('money').disable();
      this.disciplineForm.get('isActive').disable();
    } else {
      this.disciplineForm.get('isActive').setValue(true);
      this.disciplineForm.get('money').setValue(0);
      this.disciplineForm.get('name').enable();
      this.disciplineForm.get('description').enable();
      this.disciplineForm.get('money').enable();
      this.disciplineForm.get('isActive').enable();

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
    if (this.disciplineForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.disciplineService.save(this.disciplineForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.disciplineService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: DisciplineViewModel) {
    this.disciplineForm.get('id').setValue(data.id);
    this.disciplineForm.get('name').setValue(data.name);
    this.disciplineForm.get('description').setValue(data.description);
    this.disciplineForm.get('money').setValue(this.formatNumber.transform(data.money));
    this.disciplineForm.get('isActive').setValue(data.isActive);
    this.disciplineForm.get('rowVersion').setValue(data.rowVersion);
  }
}
