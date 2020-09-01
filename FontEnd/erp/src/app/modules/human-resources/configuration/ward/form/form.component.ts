import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { WardService } from '../ward.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { WardViewModel } from '../ward.model';
import { ActivatedRoute } from '@angular/router';
import { ProvinceViewModel } from '../../province/province.model';
import { DistrictViewModel } from '../../district/district.model';
import { ProvinceService } from '../../province/province.service';
import { DistrictService } from '../../district/district.service';
import { DistrictFormComponent } from '../../district/form/form.component';
import { ProvinceFormComponent } from '../../province/form/form.component';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-hr-ward-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class WardFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  wardForm: FormGroup;
  item: WardViewModel;

  provinceList: ProvinceViewModel[] = [];
  districtList: DistrictViewModel[] = [];

  districtDropdown: DistrictViewModel[] = [];

  constructor(
    public translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private wardService: WardService,
    private provinceService: ProvinceService,
    private districtService: DistrictService,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(res => {
      this.provinceList = res.data.provinces.result;
      this.districtList = res.data.districts.result;
    });
    this.wardForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      districtId: [null, [Validators.required]],
      provinceId: [null, [Validators.required]],
      precedence: [1, [Validators.required]],
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
    this.wardForm.get('id').setValue(0);
    this.wardForm.get('name').reset();
    this.wardForm.get('districtId').reset();
    this.wardForm.get('provinceId').reset();
    this.wardForm.get('precedence').reset();
    this.wardForm.get('isActive').reset();

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

    this.elm.nativeElement.querySelector('#provinceId').focus();
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  onAddNewProvinceClick() {
    this.provinceService.openPopupForm(ProvinceFormComponent).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.provinceList = response.result;
      }
    });
  }

  onAddNewDistrictClick() {
    this.districtService.openPopupForm(DistrictFormComponent).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.districtList = response.result;
      }
    });
  }

  onProvinceChange(province?: ProvinceViewModel) {
    this.districtDropdown = [];
    if (province) {
      this.wardForm.get('districtId').enable();
      this.districtDropdown = this.districtList.filter(m => m.provinceId === province.id);
    } else {
      this.wardForm.get('districtId').disable();
    }
    this.wardForm.get('districtId').setValue(null);
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#provinceId').focus();
    this.translate.get('SCREEN.HR.CONFIGURATION.WARD.FORM.TITLE_NEW').subscribe(message => {
      this.formTitle = message;
    });
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.translate.get('SCREEN.HR.CONFIGURATION.WARD.FORM.TITLE_EDIT').subscribe(message => {
      this.formTitle = message;
    });
  }

  onResetClick() {
    switch(this.formAction) {
      case FormActionStatus.Insert:
        this.initFormControl(this.formAction);
        break;
      case FormActionStatus.Update:
        this.setDataToForm(this.item);
        this.elm.nativeElement.querySelector('#provinceId').focus();
        break;
    }
  }

  onCloseClick() {
    this.initFormControl(FormActionStatus.UnKnow);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.wardForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.wardService.save(this.wardForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
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
    this.wardService.item(id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: WardViewModel) {
    this.districtDropdown = [];
    this.districtDropdown = this.districtList.filter(m => m.provinceId === data.provinceId);
    setTimeout(() => {
      this.wardForm.get('id').setValue(data.id);
      this.wardForm.get('name').setValue(data.name);
      this.wardForm.get('districtId').setValue(data.districtId);
      this.wardForm.get('provinceId').setValue(data.provinceId);
      this.wardForm.get('precedence').setValue(data.precedence);
      this.wardForm.get('isActive').setValue(data.isActive);
      this.wardForm.get('rowVersion').setValue(data.rowVersion);
    }, 300);
  }
}
