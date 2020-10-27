import { Component, OnInit, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { TranslateService } from '@ngx-translate/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { PermissionViewModel } from './../../../../../core/models/permission.model';
import { DistrictService } from '../district.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DistrictViewModel } from '../district.model';
import { ProvinceViewModel } from '../../province/province.model';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { ProvinceService } from '../../province/province.service';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';
import { ProvinceFormComponent } from '../../province/form/form.component';

@Component({
  selector: 'app-hr-district-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class DistrictFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  formAction = FormActionStatus.UnKnow;
  permission = new PermissionViewModel();
  provincePermission = new PermissionViewModel();

  formTitle = '';
  isSubmit = false;
  isLoading = false;
  districtForm: FormGroup;
  item: DistrictViewModel;

  listProvince: ProvinceViewModel[] = [];

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<DistrictFormComponent>,
    private elm: ElementRef,
    private fb: FormBuilder,
    private districtService: DistrictService,
    private provinceService: ProvinceService) {
  }

  ngOnInit(): void {
    let title = 'SCREEN.HR.CONFIGURATION.DISTRICT.FORM.TITLE_NEW';
    this.permission = this.districtService.getPermission();
    this.provincePermission = this.provinceService.getPermission();
    this.districtForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      provinceId: ['', [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true],
      rowVersion: [null],
    });

    this.initFormControl(FormActionStatus.Insert);
    if (this.dialogData) {
      this.listProvince = this.dialogData.listProvince;
      if (this.dialogData.itemId) {
        title = 'SCREEN.HR.CONFIGURATION.DISTRICT.FORM.TITLE_EDIT';
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
    this.districtForm.get('id').setValue(0);
    this.districtForm.get('name').reset();
    this.districtForm.get('provinceId').setValue('');
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
    this.elm.nativeElement.querySelector('#provinceId').focus();
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  allowAddProvince() {
    if (this.provincePermission.allowInsert) {
      return true;
    }
    return false;
  }

  onAddNewProvinceClick() {
    this.provinceService.openPopupForm(ProvinceFormComponent).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listProvince = response.result;
      }
    });
  }

  onResetClick() {
    switch (this.formAction) {
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
    this.dialogRef.close(false);
  }

  onProvinceSearch(term: string, item: any) {
    term = term.toLocaleLowerCase();
    return item.name.toLocaleLowerCase().indexOf(term) > -1 || item.name.toLocaleLowerCase().indexOf(term) > -1;
  }

  submitForm() {
    this.isSubmit = true;
    if (this.districtForm.invalid) {
      return;
    }
    this.isLoading = true;

    this.districtService.save(this.districtForm.getRawValue(), this.formAction).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.dialogRef.close(true);
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  private getItem(id: number) {
    this.isLoading = true;
    this.districtService.item(id).subscribe((response: ResponseModel) => {
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.item = response.result;
        this.setDataToForm(this.item);
      }
      this.isLoading = false;
    });
  }

  private setDataToForm(data: DistrictViewModel) {
    this.districtForm.get('id').setValue(data.id);
    this.districtForm.get('name').setValue(data.name);
    this.districtForm.get('provinceId').setValue(data.provinceId);
    this.districtForm.get('precedence').setValue(data.precedence);
    this.districtForm.get('isActive').setValue(data.isActive);
    this.districtForm.get('rowVersion').setValue(data.rowVersion);
  }

}
