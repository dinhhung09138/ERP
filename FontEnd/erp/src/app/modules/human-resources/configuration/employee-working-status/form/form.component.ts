import { Component, ElementRef, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { EmployeeWorkingStatusViewModel } from '../employee-working-status.model';
import { EmployeeWorkingStatusService } from '../employee-working-status.service';

@Component({
  selector: 'app-hr-employee-working-status-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class EmployeeWorkingStatusFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isShow = false;
  isSubmit = false;
  isLoading = false;
  workingStatusForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private workingStatusService: EmployeeWorkingStatusService
  ) { }

  ngOnInit(): void {
    this.workingStatusForm = this.fb.group({
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

    this.formAction = formStatus;
    this.workingStatusForm.get('id').setValue(0);
    this.workingStatusForm.get('code').reset();
    this.workingStatusForm.get('name').reset();
    this.workingStatusForm.get('description').reset();
    this.workingStatusForm.get('isActive').reset();
    this.workingStatusForm.get('precedence').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.workingStatusForm.get('code').disable();
      this.workingStatusForm.get('name').disable();
      this.workingStatusForm.get('description').disable();
      this.workingStatusForm.get('isActive').disable();
      this.workingStatusForm.get('precedence').disable();
    } else {
      this.isShow = true;
      this.workingStatusForm.get('isActive').setValue(true);
      this.workingStatusForm.get('precedence').setValue(1);
      this.workingStatusForm.get('name').enable();
      this.workingStatusForm.get('description').enable();
      this.workingStatusForm.get('isActive').enable();
      this.workingStatusForm.get('precedence').enable();

      if (formStatus === FormActionStatus.Create) {
        this.workingStatusForm.get('code').enable();
        this.elm.nativeElement.querySelector('#code').focus();
      } else {
        this.elm.nativeElement.querySelector('#name').focus();
      }
    }
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Create) {
      this.initFormControl(FormActionStatus.Create);
    }
    this.elm.nativeElement.querySelector('#code').focus();
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
    if (this.workingStatusForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.workingStatusForm.getRawValue() as EmployeeWorkingStatusViewModel;
    model.action = this.formAction;

    this.workingStatusService.save(model).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.workingStatusService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.workingStatusForm.get('id').setValue(response.result.id);
        this.workingStatusForm.get('code').setValue(response.result.code);
        this.workingStatusForm.get('name').setValue(response.result.name);
        this.workingStatusForm.get('description').setValue(response.result.description);
        this.workingStatusForm.get('precedence').setValue(response.result.precedence);
        this.workingStatusForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
