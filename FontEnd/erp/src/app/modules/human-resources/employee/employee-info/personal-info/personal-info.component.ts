import { Component, OnInit, Input, ViewChild, OnChanges, SimpleChanges, ChangeDetectionStrategy } from '@angular/core';
import { PersonalInfoService } from './personal-info.service';
import { PersonalInfoViewModel } from './personal-info.model';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { FormGroup, FormBuilder, Validators, FormGroupDirective } from '@angular/forms';
import { NationViewModel } from '../../../configuration/nation/nation.model';
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

  @Input() Employee: EmployeeViewModel;


  isInitData = false; // Set true after get all init data in the first time.
  isEdit = false; // If true, enable control for editing
  gender = -1; // -1: Unknow, 1: Male, 2: Female
  isLoading = false;
  isSubmit = false;
  personalInfo: PersonalInfoViewModel;
  personalInfoForm: FormGroup;

  nationList: NationViewModel[];
  nationalityList: NationalityViewModel[];
  educationList: EducationViewModel[];
  religionList: ReligionViewModel[];
  qualificationList: ProfessionalQualificationViewModel[];

  constructor(
    private personalInfoService: PersonalInfoService,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.personalInfoForm = this.fb.group({
      id: [0],
      employeeId: [0, [Validators.required]],
      dateOfBirth: [0],
      gender: [true],
      materialStatusId: [null],
      religionId: [null],
      nationId: [null],
      nationalityId: [null],
      academicLevelId: [null],
      professionalQualificationId: [null],
    });
  }

  ngOnChanges(data: SimpleChanges) {
    if (data.Employee && data.Employee.currentValue) {
      if (this.isInitData === false) {
        this.getSelection();
        this.isInitData = true;
      }
      this.initFormControl();
      this.item();
    }
  }

  initFormControl() {
    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.personalInfoForm.get('id').setValue(0);
    this.personalInfoForm.get('employeeId').setValue(this.Employee.id);
    this.personalInfoForm.get('dateOfBirth').setValue(null);
    this.personalInfoForm.get('gender').setValue(true);
    this.personalInfoForm.get('materialStatusId').setValue(null);
    this.personalInfoForm.get('religionId').setValue(null);
    this.personalInfoForm.get('nationId').setValue(null);
    this.personalInfoForm.get('nationalityId').setValue(null);
    this.personalInfoForm.get('academicLevelId').setValue(null);
    this.personalInfoForm.get('professionalQualificationId').setValue(null);
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

  item() {
    if (this.Employee) {
      this.isLoading = true;
      this.personalInfoService.item(this.Employee.id).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.personalInfo = response.result;
          this.setDataToForm(this.personalInfo);
        }
        this.isLoading = false;
      });
    }
  }

  onGenderChange(isMale: number) {
    this.personalInfoForm.get('gender').setValue(isMale === 1 ? true : false);
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

  private getSelection() {
    this.isLoading = true;
    this.personalInfoService.getSelection().subscribe(response => {
      if (response.nations && response.nations.responseStatus === ResponseStatus.success) {
        this.nationList = response.nations.result;
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
      this.personalInfoForm.get('employeeId').setValue(this.Employee.id);
      if (data.dateOfBirth) {
        this.personalInfoForm.get('dateOfBirth').setValue(new Date(data.dateOfBirth));
      }
      this.personalInfoForm.get('gender').setValue(data.gender);
      this.gender = data.gender === null ? -1 : data.gender === true ? 1 : 0;
      this.personalInfoForm.get('materialStatusId').setValue(data.materialStatusId);
      this.personalInfoForm.get('religionId').setValue(data.religionId);
      this.personalInfoForm.get('nationId').setValue(data.nationId);
      this.personalInfoForm.get('nationalityId').setValue(data.nationalityId);
      this.personalInfoForm.get('academicLevelId').setValue(data.academicLevelId);
      this.personalInfoForm.get('professionalQualificationId').setValue(data.professionalQualificationId);
    }
  }

}
