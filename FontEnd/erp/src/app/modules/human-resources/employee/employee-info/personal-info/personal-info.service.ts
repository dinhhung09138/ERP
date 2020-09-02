import { Injectable } from '@angular/core';
import { ApiService } from '../../../../../core/services/api.service';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { PersonalInfoViewModel } from './personal-info.model';
import { Observable, forkJoin } from 'rxjs';
import { ResponseModel } from '../../../../../core/models/response.model';
import { EthnicityService } from '../../../configuration/ethnicity/ethnicity.service';
import { ReligionService } from '../../../configuration/religion/religion.service';
import { NationalityService } from '../../../configuration/nationality/nationality.service';
import { EducationService } from '../../../configuration/education/education.service';
import { ProfessionalQualificationService } from '../../../configuration/professional-qualification/professional-qualification.service';
import { map } from 'rxjs/operators';
import { EthnicityFormComponent } from '../../../configuration/ethnicity/form/form.component';
import { NationalityFormComponent } from '../../../configuration/nationality/form/form.component';
import { EducationFormComponent } from '../../../configuration/education/form/form.component';
import { ProfessionalQualificationFormComponent } from '../../../configuration/professional-qualification/form/form.component';
import { ReligionFormComponent } from '../../../configuration/religion/form/form.component';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PersonalInfoService {

  constructor(
    private http: HttpClient,
    private api: ApiService,
    private ethnicityService: EthnicityService,
    private nationalityService: NationalityService,
    private religionService: ReligionService,
    private educationService: EducationService,
    private qualificationService: ProfessionalQualificationService) { }

  url = {
    item: APIUrlConstants.hrApi + 'employee-info/item',
    itemByEmployeeId: APIUrlConstants.hrApi + 'employee-info/item-by-employee',
    update: APIUrlConstants.hrApi + 'employee-info/update',
  };

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
    return this.api.update(this.url.update, model);
  }

  getSelection(): Observable<any> {
    return forkJoin([
      this.ethnicityService.getDropdown(),
      this.nationalityService.getDropdown(),
      this.religionService.getDropdown(),
      this.educationService.getDropdown(),
      this.qualificationService.getDropdown(),
    ]).pipe(
      map(
        ([ethnicityData, nationalityData, religionData, educationData, qualificationData]) => {
          return {
            ethnicity: ethnicityData,
            nationalities: nationalityData,
            religions: religionData,
            educations: educationData,
            qualifications: qualificationData,
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
