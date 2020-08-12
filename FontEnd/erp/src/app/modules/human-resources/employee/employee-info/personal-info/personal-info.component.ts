import { Component, OnInit, Input, ViewChild } from '@angular/core';
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

@Component({
  selector: 'app-hr-employee-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.scss']
})
export class PersonalInfoComponent implements OnInit {

  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  @Input() EmployeeId: number;


  isInitData = false; // Set true after get all init data in the first time.
  isEdit = false; // If true, enable control for editing
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
    this.EmployeeId = 0;

    this.personalInfoForm = this.fb.group({
      id: [0],
      employeeId: [0, [Validators.required]],
      dateOfBirth: [0, ],
      gender: [true, [Validators.required]],
      materialStatusId: [null],
      religionId: [null],
      nationId: [null],
      nationalityId: [null],
      academicLevelId: [null],
      professionalQualificationId: [null],
    });
    this.initFormControl();
    this.getSelection();
  }

  initFormControl() {
    if (this.formDirective) {
      this.formDirective.resetForm();
    }

    this.personalInfoForm.get('id').setValue(0);
    this.personalInfoForm.get('employeeId').setValue(this.EmployeeId);
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
  }

  onResetClick() {
    this.initFormControl();

  }

  item() {
    this.isSubmit = false;
    if (this.EmployeeId) {
      this.isLoading = true;
      this.personalInfoService.item(this.EmployeeId).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.personalInfo = response.result;
          this.isSubmit = true;
        }
        this.isLoading = false;
      });
    }
  }

  onGenderChange(isMale: boolean) {
    this.personalInfoForm.get('gender').setValue(isMale);
  }

  onSubmit() {
    this.isSubmit = true;

    if (this.personalInfoForm.invalid) {
      return;
    }
    this.isLoading = true;
    console.log(this.personalInfoForm.getRawValue());
    this.personalInfoService.save(this.personalInfoForm.getRawValue()).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.isLoading = false;
        this.isSubmit = false;
      }
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
      console.log(this.educationList);
      console.log(this.qualificationList);
      console.log(this.religionList);
      console.log(this.nationList);
      console.log(this.nationalityList);
    });
  }

}
