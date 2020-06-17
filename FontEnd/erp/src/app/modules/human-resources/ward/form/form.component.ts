import { Component, OnInit, Output, EventEmitter, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { WardService } from '../ward.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { WardViewModel } from '../ward.model';
import { ActivatedRoute } from '@angular/router';
import { ProvinceViewModel } from '../../province/province.model';
import { DistrictViewModel } from '../../district/district.model';

@Component({
  selector: 'app-hr-ward-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class WardFormComponent implements OnInit {

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  isSubmit = false;
  isLoading = false;
  wardForm: FormGroup;

  provinceList: ProvinceViewModel[] = [];
  districtList: DistrictViewModel[] = [];

  districtDropdown: DistrictViewModel[] = [];

  constructor(
    private elm: ElementRef,
    private fb: FormBuilder,
    private wardService: WardService,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(res => {
      this.provinceList = res.data.provinces.result;
      this.districtList = res.data.districts.result;
      console.log(this.districtList);
    });
    this.wardForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      districtId: [null, [Validators.required]],
      provinceId: [null, [Validators.required]],
      precedence: [1, [Validators.required]],
      isActive: [true]
    });
    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus, isDisabledForm: boolean = true) {
    this.isSubmit = false;

    this.formAction = formStatus;
    this.wardForm.get('id').setValue(0);
    this.wardForm.get('name').reset();
    this.wardForm.get('districtId').reset();
    this.wardForm.get('provinceId').reset();
    this.wardForm.get('precedence').reset();
    this.wardForm.get('isActive').reset();

    if (isDisabledForm) {
      if (formStatus === FormActionStatus.UnKnow) {
        this.wardForm.get('name').disable();
        this.wardForm.get('districtId').disable();
        this.wardForm.get('provinceId').disable();
        this.wardForm.get('precedence').disable();
        this.wardForm.get('isActive').disable();
      } else {
        this.wardForm.get('isActive').setValue(true);
        this.wardForm.get('precedence').setValue(1);
        this.wardForm.get('name').enable();
        this.wardForm.get('districtId').enable();
        this.wardForm.get('provinceId').enable();
        this.wardForm.get('precedence').enable();
        this.wardForm.get('isActive').enable();
      }
    }
    this.elm.nativeElement.querySelector('#name').focus();
  }

  provinceChange(province?: ProvinceViewModel) {
    console.log(province);
    this.districtDropdown = [];
    if (province) {
      this.wardForm.get('districtId').enable();
      this.districtDropdown = this.districtList.filter(m => m.provinceId === province.id);
    } else {
      this.wardForm.get('districtId').disable();
    }
    this.wardForm.get('districtId').setValue(null);
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
    if (this.wardForm.invalid) {
      return;
    }
    this.isLoading = true;
    const model = this.wardForm.value as WardViewModel;
    model.action = this.formAction;

    this.wardService.save(model).subscribe((res: ResponseModel) => {
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
    this.wardService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null) {
        this.wardForm.get('id').setValue(response.result.id);
        this.wardForm.get('name').setValue(response.result.name);
        this.wardForm.get('districtId').setValue(response.result.districtId);
        this.wardForm.get('provinceId').setValue(response.result.provinceId);
        this.wardForm.get('precedence').setValue(response.result.precedence);
        this.wardForm.get('isActive').setValue(response.result.isActive);
      }
      this.isLoading = false;
    });
  }

}
