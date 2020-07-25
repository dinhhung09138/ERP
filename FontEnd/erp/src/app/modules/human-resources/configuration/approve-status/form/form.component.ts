import { AppValidator } from 'src/app/core/validators/app.validator';
import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { ApproveStatusService } from '../approve-status.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ApproveStatusViewModel } from '../approve-status.model';

@Component({
  selector: 'app-hr-approve-status-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ApproveStatusFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isShow = false;
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
    this.approveStatusForm.get('id').setValue(0);
    this.approveStatusForm.get('code').reset();
    this.approveStatusForm.get('name').reset();
    this.approveStatusForm.get('precedence').reset();
    this.approveStatusForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.isShow = false;
      this.approveStatusForm.get('code').disable();
      this.approveStatusForm.get('name').disable();
      this.approveStatusForm.get('precedence').disable();
      this.approveStatusForm.get('isActive').disable();
    } else {
      this.isShow = true;
      this.approveStatusForm.get('name').enable();
      this.approveStatusForm.get('precedence').enable();
      this.approveStatusForm.get('isActive').enable();
      this.approveStatusForm.get('precedence').setValue(1);
      this.approveStatusForm.get('isActive').setValue(true);

      if (formStatus === FormActionStatus.Create) {
        this.elm.nativeElement.querySelector('#code').focus();
        this.approveStatusForm.get('code').enable();
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

  onSubmitForm() {
    this.isSubmit = true;
    if (this.approveStatusForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.approveStatusForm.getRawValue() as ApproveStatusViewModel;
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
    this.approveStatusService.item(id).subscribe((res: ResponseModel) => {
      if (res !== null) {
        this.approveStatusForm.get('id').setValue(res.result.id);
        this.approveStatusForm.get('code').setValue(res.result.code);
        this.approveStatusForm.get('name').setValue(res.result.name);
        this.approveStatusForm.get('precedence').setValue(res.result.precedence);
        this.approveStatusForm.get('isActive').setValue(res.result.isActive);
      }
      this.isLoading = false;
    });
  }
}
