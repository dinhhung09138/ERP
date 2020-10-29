import { Component, OnInit, Input, ViewChild, OnChanges, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';

import { PersonalInfoService } from './personal-info.service';
import { PersonalInfoViewModel } from './personal-info.model';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { EthnicityViewModel } from '../../../configuration/ethnicity/ethnicity.model';
import { NationalityViewModel } from '../../../configuration/nationality/nationality.model';
import { EducationViewModel } from '../../../configuration/education/education.model';
import { ReligionViewModel } from '../../../configuration/religion/religion.model';
import { ProfessionalQualificationViewModel } from '../../../configuration/professional-qualification/professional-qualification.model';
import { EmployeeViewModel } from '../../employee.model';

@Component({
  selector: 'app-hr-employee-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.scss']
})
export class PersonalInfoComponent implements OnInit, OnChanges {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Input() employee: EmployeeViewModel;

  isEdit = false; // If true, enable control for editing
  isLoading = false;
  isSubmit = false;
  personalInfo: PersonalInfoViewModel;
  personalInfoForm: FormGroup;

  ethnicityLoading = false;
  ethnicityList: EthnicityViewModel[];
  nationalityLoading = false;
  nationalityList: NationalityViewModel[];
  educationLoading = false;
  educationList: EducationViewModel[];
  religionLoading = false;
  religionList: ReligionViewModel[];
  qualificationLoading = false;
  qualificationList: ProfessionalQualificationViewModel[];

  constructor(
    private personalInfoService: PersonalInfoService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.personalInfoForm = this.fb.group({
      id: [0],
      employeeId: [0],
      dateOfBirth: [null],
      gender: [true, [Validators.required]],
      materialStatusId: [''],
      religionId: [''],
      ethnicityId: [''],
      nationalityId: [''],
      academicLevelId: [''],
      professionalQualificationId: [''],
      rowVersion: [null],
    });
    this.initFormControl();
  }

  ngOnChanges(data: SimpleChanges) {
    if (data.employee && data.employee.currentValue) {
      console.log(data.employee.currentValue.id);
      this.personalInfoForm.get('employeeId').setValue(data.employee.currentValue.id);
      this.getInfoByEmployeeId(data.employee.currentValue.id);
    }
  }

  initFormControl() {

    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.personalInfoForm.get('id').setValue(0);
    this.personalInfoForm.get('employeeId').setValue(null);
    this.personalInfoForm.get('dateOfBirth').setValue(null);
    this.personalInfoForm.get('gender').setValue(true);
    this.personalInfoForm.get('materialStatusId').setValue('');
    this.personalInfoForm.get('religionId').setValue('');
    this.personalInfoForm.get('ethnicityId').setValue('');
    this.personalInfoForm.get('nationalityId').setValue('');
    this.personalInfoForm.get('academicLevelId').setValue('');
    this.personalInfoForm.get('professionalQualificationId').setValue('');

  }

  onEditClick() {
    this.isEdit = true;
  }

  onCancelClick() {
    this.isEdit = false;
    this.initFormControl();
    this.setDataToForm(this.personalInfo);
  }

  onResetClick() {
    this.initFormControl();
    this.setDataToForm(this.personalInfo);
  }

  private getInfoByEmployeeId(employeeId: number) {
    if (this.employee) {
      this.isLoading = true;
      this.personalInfoService.getInfoByEmployeeId(employeeId).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.personalInfo = response.result;
          this.setDataToForm(this.personalInfo);
        }
        this.isLoading = false;
      });
    }
  }

  onAddNewEthnicityClick() {
    this.ethnicityLoading = true;
    this.personalInfoService.addNewEthnicity().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('ethnicityId').setValue(null);
        this.ethnicityList = response.result;
      }
      this.ethnicityLoading = false;
    });
  }

  onAddNewNationalityClick() {
    this.nationalityLoading = true;
    this.personalInfoService.addNewNationality().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('nationalityId').setValue(null);
        this.nationalityList = response.result;
      }
      this.nationalityLoading = false;
    });
  }

  onAddNewReligionClick() {
    this.religionLoading = true;
    this.personalInfoService.addNewReligion().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('religionId').setValue(null);
        this.religionList = response.result;
      }
      this.religionLoading = false;
    });
  }

  onAddNewEducationClick() {
    this.educationLoading = true;
    this.personalInfoService.addNewEducation().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('academicLevelId').setValue(null);
        this.educationList = response.result;
      }
      this.educationLoading = false;
    });
  }

  onAddNewQualificationClick() {
    this.qualificationLoading = true;
    this.personalInfoService.addNewQualification().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('professionalQualificationId').setValue(null);
        this.qualificationList = response.result;
      }
      this.qualificationLoading = false;
    });
  }

  onSubmit() {

    this.isSubmit = true;

    console.log(this.personalInfoForm.getRawValue());

    if (this.personalInfoForm.invalid) {
      this.isSubmit = false;
      return;
    }
    this.isLoading = true;
    this.personalInfoService.save(this.personalInfoForm.getRawValue()).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfo = this.personalInfoForm.getRawValue();
        this.isEdit = false;
      }
      this.isLoading = false;
      this.isSubmit = false;
    });
  }

  public getSelection() {
    this.isLoading = true;
    this.personalInfoService.getSelection().subscribe(response => {
      if (response.ethnicity && response.ethnicity.responseStatus === ResponseStatus.success) {
        this.ethnicityList = response.ethnicity.result;
      }
      if (response.nationalities && response.nationalities.responseStatus === ResponseStatus.success) {
        this.nationalityList = response.nationalities.result;
      }
      if (response.religions && response.religions.responseStatus === ResponseStatus.success) {
        this.religionList = response.religions.result;
      }
      if (response.educations && response.educations.responseStatus === ResponseStatus.success) {
        this.educationList = response.educations.result;
      }
      if (response.qualifications && response.qualifications.responseStatus === ResponseStatus.success) {
        this.qualificationList = response.qualifications.result;
      }

      this.isLoading = false;
    });
  }

  private setDataToForm(data?: PersonalInfoViewModel) {
    if (data) {
      this.personalInfoForm.get('id').setValue(data.id);
      this.personalInfoForm.get('employeeId').setValue(this.employee.id);
      if (data.dateOfBirth) {
        this.personalInfoForm.get('dateOfBirth').setValue(new Date(data.dateOfBirth));
      }
      this.personalInfoForm.get('gender').setValue(data.gender);
      this.personalInfoForm.get('materialStatusId').setValue(data.materialStatusId || '');
      this.personalInfoForm.get('religionId').setValue(data.religionId || '');
      this.personalInfoForm.get('ethnicityId').setValue(data.ethnicityId || '');
      this.personalInfoForm.get('nationalityId').setValue(data.nationalityId || '');
      this.personalInfoForm.get('academicLevelId').setValue(data.academicLevelId || '');
      this.personalInfoForm.get('professionalQualificationId').setValue(data.professionalQualificationId || '');
      this.personalInfoForm.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
