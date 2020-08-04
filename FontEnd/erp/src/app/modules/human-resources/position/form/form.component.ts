import { AppValidator } from 'src/app/core/validators/app.validator';
import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { PositionService } from '../position.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PositionViewModel } from '../position.model';

@Component({
  selector: 'app-hr-position-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class PositionFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
  isSubmit = false;
  isLoading = false;
  PositionForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private PositionService: PositionService) { }

  ngOnInit(): void {
    this.PositionForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      description: [''],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.PositionForm.get('id').setValue(0);
    this.PositionForm.get('code').reset();
    this.PositionForm.get('name').reset();
    this.PositionForm.get('description').reset();
    this.PositionForm.get('precedence').reset();
    this.PositionForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.PositionForm.get('code').disable();
      this.PositionForm.get('name').disable();
      this.PositionForm.get('description').disable();
      this.PositionForm.get('precedence').disable();
      this.PositionForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.PositionForm.get('name').enable();
      this.PositionForm.get('description').enable();
      this.PositionForm.get('precedence').enable();
      this.PositionForm.get('isActive').enable();
      this.PositionForm.get('precedence').setValue(1);
      this.PositionForm.get('isActive').setValue(true);

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
    this.formTitle = 'Thêm mới';
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.formTitle = 'Cập nhật';
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.PositionForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.PositionService.save(this.PositionForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.PositionService.item(id).subscribe((res: ResponseModel) => {
      if (res !== null) {
        this.PositionForm.get('id').setValue(res.result.id);
        this.PositionForm.get('code').setValue(res.result.code);
        this.PositionForm.get('name').setValue(res.result.name);
        this.PositionForm.get('description').setValue(res.result.description);
        this.PositionForm.get('precedence').setValue(res.result.precedence);
        this.PositionForm.get('isActive').setValue(res.result.isActive);
      }
      this.isLoading = false;
    });
  }
}
