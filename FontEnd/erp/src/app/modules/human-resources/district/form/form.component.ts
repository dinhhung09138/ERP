import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DistrictService } from '../district.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DistrictViewModel } from '../district.model';
import { ProvinceViewModel } from '../../province/province.model';
import { ActivatedRoute } from '@angular/router';
import { AppValidator } from 'src/app/core/validators/app.validator';

@Component({
  selector: 'app-hr-district-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class DistrictFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  districtForm: FormGroup;

  provinceList: ProvinceViewModel[] = [];

  constructor(
    private elm: ElementRef,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private districtService: DistrictService) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(res => {
      this.provinceList = res.province.result;
    });
    this.districtForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      provinceId: [null, [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.districtForm.get('id').setValue(0);
    this.districtForm.get('name').reset();
    this.districtForm.get('provinceId').reset();
    this.districtForm.get('precedence').reset();
    this.districtForm.get('isActive').reset();

    if (formStatus === FormActionStatus.UnKnow) {
      this.districtForm.get('name').disable();
      this.districtForm.get('provinceId').disable();
      this.districtForm.get('precedence').disable();
      this.districtForm.get('isActive').disable();
    } else {
      this.districtForm.get('isActive').setValue(true);
      this.districtForm.get('precedence').setValue(1);
      this.districtForm.get('name').enable();
      this.districtForm.get('provinceId').enable();
      this.districtForm.get('precedence').enable();
      this.districtForm.get('isActive').enable();
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Create) {
      this.initFormControl(FormActionStatus.Create);
    }
    this.elm.nativeElement.querySelector('#name');
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
    if (this.districtForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.districtForm.value as DistrictViewModel;
    model.action = this.formAction;

    this.districtService.save(model).subscribe((res: ResponseModel) => {
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
    this.districtService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.districtForm.get('id').setValue(response.result.id);
        this.districtForm.get('name').setValue(response.result.name);
        this.districtForm.get('provinceId').setValue(response.result.provinceId);
        this.districtForm.get('precedence').setValue(response.result.precedence);
        this.districtForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
