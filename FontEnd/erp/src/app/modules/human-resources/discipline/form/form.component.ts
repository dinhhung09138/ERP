import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { DisciplineService } from '../discipline.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DisciplineViewModel } from '../discipline.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';

@Component({
  selector: 'app-hr-discipline-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class DisciplineFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  disciplineForm: FormGroup;
  item: DisciplineViewModel;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private formatNumber: FormatNumberPipe,
    private disciplineService: DisciplineService) { }

  ngOnInit(): void {
    this.disciplineForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
      money: [0, [Validators.required, AppValidator.money]],
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
  }

  submitForm() {
    this.isSubmit = true;
    if (this.disciplineForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.disciplineService.save(this.disciplineForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
