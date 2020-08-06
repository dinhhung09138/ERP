import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { DistrictService } from '../district.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { DistrictViewModel } from '../district.model';
import { ProvinceViewModel } from '../../province/province.model';
import { ActivatedRoute } from '@angular/router';
import { AppValidator } from 'src/app/core/validators/app.validator';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProvinceFormComponent } from '../../province/form/form.component';
import { ProvinceService } from '../../province/province.service';
import { DialogDataInterface } from '../../../../../core/interfaces/dialog-data.interface';

@Component({
  selector: 'app-hr-district-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class DistrictFormComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Output() reloadTableEvent = new EventEmitter<boolean>();

  formAction = FormActionStatus.UnKnow;

  formTitle = '';
  isSubmit = false;
  // Show loading when the form have a action call to server
  isLoading = false;
  districtForm: FormGroup;
  item: DistrictViewModel;

  provinceList: ProvinceViewModel[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public dialogData: DialogDataInterface,
    private dialogRef: MatDialogRef<DistrictFormComponent>,
    private elm: ElementRef,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private districtService: DistrictService,
    private provinceService: ProvinceService) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(res => {
      this.provinceList = res.province.result as ProvinceViewModel[];
    });
    this.districtForm = this.fb.group({
      id: [0],
      name: ['', [Validators.required]],
      provinceId: [null, [Validators.required]],
      precedence: [1, [Validators.required, AppValidator.number]],
      isActive: [true]
    });

    if (this.dialogData && this.dialogData.isPopup === true) {
      this.formTitle = this.dialogData?.title;
      this.formAction = FormActionStatus.Insert;
      this.getListProvince();
    }

    this.initFormControl(this.formAction);
  }

  initFormControl(formStatus: FormActionStatus) {
    this.isSubmit = false;

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

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
    this.elm.nativeElement.querySelector('#provinceId').focus();
  }

  showFormStatus() {
    if (this.formAction === FormActionStatus.UnKnow) {
      return false;
    }
    return true;
  }

  getClassByFormOrPopup() {
    if (this.dialogData?.isPopup === true) {
      return 'col-12';
    }
    return 'col-lg-8 col-md-12 col-sm-12 col-xs-12';
  }

  allowAddProvince() {
    if (Object.prototype.hasOwnProperty.call(this.dialogData, 'isPopup') === false) {
      return true;
    }
    if (this.dialogData.isPopup === false) {
      return true;
    }
    return false;
  }

  onAddNewProvinceClick() {
    this.provinceService.openPopupForm().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.provinceList = response.result;
      }
    });
  }

  onCreateClick() {
    if (this.formAction !== FormActionStatus.Insert) {
      this.initFormControl(FormActionStatus.Insert);
    }
    this.elm.nativeElement.querySelector('#provinceId');
    this.formTitle = 'Thêm mới';
  }

  onUpdateClick(id: number) {
    this.initFormControl(FormActionStatus.Update);
    this.getItem(id);
    this.formTitle = 'Cập nhật';
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
    this.initFormControl(FormActionStatus.UnKnow);
    if (this.dialogData?.isPopup === true) {
      this.dialogRef.close(false);
    }
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
        this.initFormControl(FormActionStatus.UnKnow);
        this.reloadTableEvent.emit(true);
      }
      this.isLoading = false;
      this.isSubmit = false;

      if (this.dialogData?.isPopup === true) {
        this.dialogRef.close(true);
      }
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
  }

  private getListProvince() {
    this.provinceService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.provinceList = response.result;
      }
    });
  }

}
