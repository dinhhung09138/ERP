import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { SpecializeService } from '../specialize.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { SpecializeViewModel } from '../specialize.model';

@Component({
  selector: 'app-training-specialize-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class SpecializeFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  specializeForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private specializeService: SpecializeService) { }

  ngOnInit(): void {
    this.specializeForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      description: [''],
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
    this.specializeForm.get('id').setValue(0);
    this.specializeForm.get('name').reset();
    this.specializeForm.get('description').reset();
    this.specializeForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.specializeForm.get('name').disable();
      this.specializeForm.get('description').disable();
      this.specializeForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.specializeForm.get('isActive').setValue(true);
      this.specializeForm.get('name').enable();
      this.specializeForm.get('description').enable();
      this.specializeForm.get('isActive').enable();
      this.elm.nativeElement.querySelector('#name').focus();
    }
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  onResetClick() {
    this.initFormControl(this.formAction);
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.specializeForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.specializeForm.getRawValue() as SpecializeViewModel;
    model.action = this.formAction;

    this.specializeService.save(model).subscribe((res: ResponseModel) => {
      if (res !== null) {
        if (res.responseStatus === ResponseStatus.success) {
          this.initFormControl(FormActionStatus.UnKnow);
          this.reloadTableEvent.emit(true);
        }
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.specializeService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.specializeForm.get('id').setValue(response.result.id);
        this.specializeForm.get('name').setValue(response.result.name);
        this.specializeForm.get('description').setValue(response.result.description);
        this.specializeForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
