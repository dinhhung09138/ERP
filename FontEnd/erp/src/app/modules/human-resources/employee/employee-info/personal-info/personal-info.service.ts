import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { ApiService } from '../../../../../core/services/api.service';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { PersonalInfoViewModel } from './personal-info.model';
import { ResponseModel } from '../../../../../core/models/response.model';
import { EthnicityService } from '../../../configuration/ethnicity/ethnicity.service';
import { ReligionService } from '../../../configuration/religion/religion.service';
import { NationalityService } from '../../../configuration/nationality/nationality.service';
import { EducationService } from '../../../configuration/education/education.service';
import { ProfessionalQualificationService } from '../../../configuration/professional-qualification/professional-qualification.service';
import { EthnicityFormComponent } from '../../../configuration/ethnicity/form/form.component';
import { NationalityFormComponent } from '../../../configuration/nationality/form/form.component';
import { EducationFormComponent } from '../../../configuration/education/form/form.component';
import { ProfessionalQualificationFormComponent } from '../../../configuration/professional-qualification/form/form.component';
import { ReligionFormComponent } from '../../../configuration/religion/form/form.component';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { SessionContext } from '../../../../../core/session.context';
import { MaritalStatusService } from '../../../configuration/marital-status/marital-status.service';

@Injectable()
export class PersonalInfoService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_EMPLOYEE_PERSONAL_INFO';

  constructor(
    private http: HttpClient,
    private api: ApiService,
    private ethnicityService: EthnicityService,
    private nationalityService: NationalityService,
    private religionService: ReligionService,
    private educationService: EducationService,
    private qualificationService: ProfessionalQualificationService,
    private maritalStatusService: MaritalStatusService,
    private context: SessionContext) { }

  url = {
    item: APIUrlConstants.hrApi + 'employee-info/item',
    itemByEmployeeId: APIUrlConstants.hrApi + 'employee-info/item-by-employee',
    update: APIUrlConstants.hrApi + 'employee-info/update',
  };

  getPermission(): PermissionViewModel {
    this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
    return this.permission;
  }

  item(id: number): Observable<ResponseModel> {
    return this.api.getDataById(this.url.item, id);
  }

  getInfoByEmployeeId(employeeId: number): Observable<ResponseModel> {
    return this.http.get(this.url.itemByEmployeeId + '?employeeId=' + employeeId).pipe(
      map((response: ResponseModel) => {
        return response;
      })
    );
  }

  save(model: PersonalInfoViewModel): Observable<ResponseModel> {
    if (this.permission.allowUpdate === false) {
      return;
    }
    return this.api.update(this.url.update, model);
  }

  getSelection(): Observable<any> {
    return forkJoin([
      this.ethnicityService.getDropdown(),
      this.nationalityService.getDropdown(),
      this.religionService.getDropdown(),
      this.educationService.getDropdown(),
      this.qualificationService.getDropdown(),
      this.maritalStatusService.getDropdown(),
    ]).pipe(
      map(
        ([ethnicityData, nationalityData, religionData, educationData, qualificationData, maritalData]) => {
          return {
            ethnicity: ethnicityData,
            nationalities: nationalityData,
            religions: religionData,
            educations: educationData,
            qualifications: qualificationData,
            maritalStatus: maritalData
          };
        }
      )
    );
  }

  addNewEthnicity(): Observable<ResponseModel> {
    return this.ethnicityService.openPopup(EthnicityFormComponent);
  }

  addNewNationality(): Observable<ResponseModel> {
    return this.nationalityService.openPopupForm(NationalityFormComponent);
  }

  addNewEducation(): Observable<ResponseModel> {
    return this.educationService.openPopupForm(EducationFormComponent);
  }

  addNewQualification(): Observable<ResponseModel> {
    return this.qualificationService.openPopupForm(ProfessionalQualificationFormComponent);
  }

  addNewReligion(): Observable<ResponseModel> {
    return this.religionService.openPopupForm(ReligionFormComponent);
  }

}
