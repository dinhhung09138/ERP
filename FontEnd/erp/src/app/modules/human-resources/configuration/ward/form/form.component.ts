import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { WardService } from '../ward.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { WardViewModel } from '../ward.model';
import { ProvinceViewModel } from '../../province/province.model';
import { DistrictViewModel } from '../../district/district.model';
import { ProvinceService } from '../../province/province.service';
import { DistrictService } from '../../district/district.service';
import { DistrictFormComponent } from '../../district/form/form.component';
import { ProvinceFormComponent } from '../../province/form/form.component';
import { DialogDataViewModel } from '../../../../../core/models/dialog-data.model';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-hr-ward-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class WardFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();
  provincePermission = new PermissionViewModel();
  districtPermission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  isPopup = false;
  wardForm: FormGroup;
  item: WardViewModel;

  listProvince: ProvinceViewModel[] = [];
  listDistrict: DistrictViewModel[] = [];

  districtDropdown: DistrictViewModel[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataViewModel,
    private dialogRef: MatDialogRef<WardFormComponent>,
    public translate: TranslateService,
    private elm: ElementRef,
    private fb: FormBuilder,
    private wardService: WardService,
    private provinceService: ProvinceService,
    private districtService: DistrictService) {
  }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.WARD.FORM.TITLE_NEW';
    this.permission = this.provinceService.getPermission();
    this.provincePermission = this.provinceService.getPermission();
    this.districtPermission = this.districtService.getPermission();

    this.wardForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      districtId: ['', [Validators.required]],
      provinceId: ['', [Validators.required]],
      precedence: [1, [Validators.required]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      this.listProvince = this.dialogData.listProvince;
      this.listDistrict = this.dialogData.listDistrict;
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.WARD.FORM.TITLE_EDIT';
        this.initFormControl(FormActionStatus.Update);
        this.getItem(this.dialogData.itemId);
      }
    }
    this.translate.get(title).subscribe(message => {
      this.formTitle = message;
    });
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.formAction = formStatus;
    this.wardForm.get('id').setValue(0);
    this.wardForm.get('name').reset();
    this.wardForm.get('districtId').setValue('');
    this.wardForm.get('provinceId').setValue('');
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

  allowAddProvince() {
    if (this.isPopup === true && !this.provincePermission.allowInsert) {
      return false;
    }
    return true;
  }

  onAddNewProvinceClick() {
    this.provinceService.openPopupForm(ProvinceFormComponent).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listProvince = response.result;
      }
    });
  }

  allowAddDistrict() {
    if (this.isPopup === true && !this.districtPermission.allowInsert) {
      return false;
    }
    return true;
  }

  onAddNewDistrictClick() {
    this.districtService.openPopupForm(DistrictFormComponent).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listDistrict = response.result;
      }
    });
  }

  onProvinceChange(event?: MatSelectChange) {
    this.districtDropdown = [];
    if (event) {
      this.wardForm.get('districtId').enable();
      this.districtDropdown = this.listDistrict.filter(m => m.provinceId === event.value);
    } else {
      this.wardForm.get('districtId').disable();
    }
    this.wardForm.get('districtId').setValue('');
  }

  onResetClick() {
    switch (this.formAction) {
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
    this.dialogRef.close(false);
  }

  submitForm() {
    this.isSubmit = true;
    if (this.wardForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.wardService.save(this.wardForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
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
    this.districtDropdown = this.listDistrict.filter(m => m.provinceId === data.provinceId);
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
