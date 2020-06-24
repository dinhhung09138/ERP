import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ApproveStatusService } from '../approve-status.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ApproveStatusViewModel } from '../approve-status.model';

@Component({
  selector: 'app-commendation-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ApproveStatusFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  approveStatusForm: FormGroup;

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private approveStatusService: ApproveStatusService) { }

  ngOnInit(): void {
    this.approveStatusForm = this.fb.group({
      id: [0],
      code: ['', [Validators.required]],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required]],
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
    this.approveStatusForm.get('id').setValue(0);
    this.approveStatusForm.get('code').reset();
    this.approveStatusForm.get('name').reset();
    this.approveStatusForm.get('precedence').reset();
    this.approveStatusForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.approveStatusForm.get('code').disable();
      this.approveStatusForm.get('name').disable();
      this.approveStatusForm.get('precedence').disable();
      this.approveStatusForm.get('isActive').disable();
    } else {
      this.approveStatusForm.get('code').enable();
      this.approveStatusForm.get('name').enable();
      this.approveStatusForm.get('precedence').enable();
      this.approveStatusForm.get('isActive').enable();
      this.approveStatusForm.get('precedence').setValue(1);
      this.approveStatusForm.get('isActive').setValue(true);
    }

    this.elm.nativeElement.querySelector('#code').focus();
  }

  onCreateClick() {
    this.initFormControl(FormActionStatus.Create);
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

  onSubmitForm() {
    this.isSubmit = true;
    if (this.approveStatusForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.approveStatusForm.value as ApproveStatusViewModel;
    model.action = this.formAction;

    this.approveStatusService.save(model).subscribe((res: ResponseModel) => {
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
    this.approveStatusService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.approveStatusForm.get('id').setValue(response.result.id);
        this.approveStatusForm.get('code').setValue(response.result.code);
        this.approveStatusForm.get('name').setValue(response.result.name);
        this.approveStatusForm.get('precedence').setValue(response.result.precedence);
        this.approveStatusForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
