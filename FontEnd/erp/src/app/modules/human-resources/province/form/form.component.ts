import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProvinceService } from '../province.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ProvinceViewModel } from '../province.model';

@Component({
  selector: 'app-hr-province-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class ProvinceFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  provinceForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private provinceService: ProvinceService) { }

  ngOnInit(): void {
    this.provinceForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      precedence: [1, [Validators.required]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.provinceForm.get('id').setValue(0);
    this.provinceForm.get('name').reset();
    this.provinceForm.get('precedence').reset();
    this.provinceForm.get('isActive').reset();

    if (isDisabledForm) {
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
    }
  }

  create() {
    this.initFormControl(FormActionStatus.Create);
  }

  update(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
  }

  reset() {
    this.initFormControl(this.formAction, false);
  }

  close() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.provinceForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.provinceForm.value as ProvinceViewModel;
    model.action = this.formAction;

    this.provinceService.save(model).subscribe((res: ResponseModel) => {
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
    this.provinceService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.provinceForm.get('id').setValue(response.result.id);
        this.provinceForm.get('name').setValue(response.result.name);
        this.provinceForm.get('precedence').setValue(response.result.precedence);
        this.provinceForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
