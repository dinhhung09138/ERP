import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { PositionService } from '../position.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PositionViewModel } from '../position.model';

@Component({
  selector: 'app-hr-position-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class PositionFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  positionForm: FormGroup;
  item: PositionViewModel;

  constructor(
    private translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private positionService: PositionService) { }

  ngOnInit(): void {
    this.permission = this.positionService.getPermission();
    this.positionForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
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
    this.positionForm.get('id').setValue(0);
    this.positionForm.get('code').reset();
    this.positionForm.get('name').reset();
    this.positionForm.get('description').reset();
    this.positionForm.get('precedence').reset();
    this.positionForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.positionForm.get('code').disable();
      this.positionForm.get('name').disable();
      this.positionForm.get('description').disable();
      this.positionForm.get('precedence').disable();
      this.positionForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.positionForm.get('name').enable();
      this.positionForm.get('description').enable();
      this.positionForm.get('precedence').enable();
      this.positionForm.get('isActive').enable();
      this.positionForm.get('precedence').setValue(1);
      this.positionForm.get('isActive').setValue(true);

      if (formStatus === FormActionStatus.Insert) {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }

  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
    this.translate.get('SCREEN.HR.POSITION.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.POSITION.FORM.TITLE_EDIT').subscribe(message => {
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
  }

  submitForm() {
    this.isSubmit = true;
    if (this.positionForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.positionService.save(this.positionForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.positionService.item(id).subscribe((res: ResponseModel) => {
      if (res && res.responseStatus === ResponseStatus.success) {
        this.item = res.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }
  private setDataToForm(data: PositionViewModel) {
    this.positionForm.get('id').setValue(data.id);
    this.positionForm.get('name').setValue(data.name);
    this.positionForm.get('description').setValue(data.description);
    this.positionForm.get('isActive').setValue(data.isActive);
    this.positionForm.get('rowVersion').setValue(data.rowVersion);
  }
}
