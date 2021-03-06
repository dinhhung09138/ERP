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
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { MaritalStatusViewModel } from '../../../configuration/marital-status/marital-status.model';

@Component({
  selector: 'app-hr-employee-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.scss']
})
export class PersonalInfoComponent implements OnInit, OnChanges {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Input() employee: EmployeeViewModel;

  permission = new PermissionViewModel();
  isEdit = false; // If true, enable control for editing
  isLoading = false;
  isSubmit = false;
  personalInfo: PersonalInfoViewModel;
  personalInfoForm: FormGroup;

  ethnicityLoading = false;
  listEthnicity: EthnicityViewModel[] = [];
  nationalityLoading = false;
  listNationality: NationalityViewModel[] = [];
  educationLoading = false;
  ListEducation: EducationViewModel[] = [];
  religionLoading = false;
  listReligion: ReligionViewModel[] = [];
  qualificationLoading = false;
  listQualification: ProfessionalQualificationViewModel[] = [];
  maritalLoading = false;
  listMaritalStatus: MaritalStatusViewModel[] = [];

  constructor(
    private personalInfoService: PersonalInfoService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.permission = this.personalInfoService.getPermission();
    this.personalInfoForm = this.fb.group({
      id: [0],
      employeeId: [0],
      dateOfBirth: [null],
      gender: [true, [Validators.required]],
      maritalStatusId: [''],
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
    this.personalInfoForm.get('maritalStatusId').setValue('');
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
        this.listEthnicity = response.result;
      }
      this.ethnicityLoading = false;
    });
  }

  onAddNewNationalityClick() {
    this.nationalityLoading = true;
    this.personalInfoService.addNewNationality().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('nationalityId').setValue(null);
        this.listNationality = response.result;
      }
      this.nationalityLoading = false;
    });
  }

  onAddNewReligionClick() {
    this.religionLoading = true;
    this.personalInfoService.addNewReligion().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('religionId').setValue(null);
        this.listReligion = response.result;
      }
      this.religionLoading = false;
    });
  }

  onAddNewEducationClick() {
    this.educationLoading = true;
    this.personalInfoService.addNewEducation().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('academicLevelId').setValue(null);
        this.ListEducation = response.result;
      }
      this.educationLoading = false;
    });
  }

  onAddNewQualificationClick() {
    this.qualificationLoading = true;
    this.personalInfoService.addNewQualification().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfoForm.get('professionalQualificationId').setValue(null);
        this.listQualification = response.result;
      }
      this.qualificationLoading = false;
    });
  }

  onSubmit() {

    this.isSubmit = true;

    if (this.personalInfoForm.invalid) {
      this.isSubmit = false;
      return;
    }
    this.isLoading = true;
    this.personalInfoService.save(this.personalInfoForm.getRawValue()).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.personalInfo = response.result;
        this.setDataToForm(response.result);
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
        this.listEthnicity = response.ethnicity.result;
      }
      if (response.nationalities && response.nationalities.responseStatus === ResponseStatus.success) {
        this.listNationality = response.nationalities.result;
      }
      if (response.religions && response.religions.responseStatus === ResponseStatus.success) {
        this.listReligion = response.religions.result;
      }
      if (response.educations && response.educations.responseStatus === ResponseStatus.success) {
        this.ListEducation = response.educations.result;
      }
      if (response.qualifications && response.qualifications.responseStatus === ResponseStatus.success) {
        this.listQualification = response.qualifications.result;
      }
      if (response.maritalStatus && response.maritalStatus.responseStatus === ResponseStatus.success) {
        this.listMaritalStatus = response.maritalStatus.result;
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
      this.personalInfoForm.get('maritalStatusId').setValue(data.maritalStatusId || '');
      this.personalInfoForm.get('religionId').setValue(data.religionId || '');
      this.personalInfoForm.get('ethnicityId').setValue(data.ethnicityId || '');
      this.personalInfoForm.get('nationalityId').setValue(data.nationalityId || '');
      this.personalInfoForm.get('academicLevelId').setValue(data.academicLevelId || '');
      this.personalInfoForm.get('professionalQualificationId').setValue(data.professionalQualificationId || '');
      this.personalInfoForm.get('rowVersion').setValue(data.rowVersion);
    }
  }

}
