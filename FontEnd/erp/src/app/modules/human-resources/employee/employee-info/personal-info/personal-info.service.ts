import { Injectable } from '@angular/core';
import { ApiService } from '../../../../../core/services/api.service';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { PersonalInfoViewModel } from './personal-info.model';
import { Observable, forkJoin } from 'rxjs';
import { ResponseModel } from '../../../../../core/models/response.model';
import { NationService } from '../../../configuration/nation/nation.service';
import { ReligionService } from '../../../configuration/religion/religion.service';
import { NationalityService } from '../../../configuration/nationality/nationality.service';
import { EducationService } from '../../../configuration/education/education.service';
import { ProfessionalQualificationService } from '../../../configuration/professional-qualification/professional-qualification.service';
import { map } from 'rxjs/operators';
import { NationFormComponent } from '../../../configuration/nation/form/form.component';

@Injectable()
export class PersonalInfoService {

  constructor(
    private api: ApiService,
    private nationService: NationService,
    private nationalityService: NationalityService,
    private religionService: ReligionService,
    private educationService: EducationService,
    private qualificationService: ProfessionalQualificationService) { }

  url = {
    item: APIUrlConstants.hrApi + 'employee-info/item',
    update: APIUrlConstants.hrApi + 'employee-info/update',
  };

  item(id: number): Observable<ResponseModel> {
    return this.api.item(this.url.item, id);
  }

  save(model: PersonalInfoViewModel): Observable<ResponseModel> {
    return this.api.update(this.url.update, model);
  }

  getSelection(): Observable<any> {
    return forkJoin([
      this.nationService.getDropdown(),
      this.nationalityService.getDropdown(),
      this.religionService.getDropdown(),
      this.educationService.getDropdown(),
      this.qualificationService.getDropdown(),
    ]).pipe(
      map(
        ([nationData, nationalityData, religionData, educationData, qualificationData]) => {
          return {
            nations: nationData,
            nationalities: nationalityData,
            religions: religionData,
            educations: educationData,
            qualifications: qualificationData,
          };
        }
      )
    );
  }

  addNewNation(): Observable<ResponseModel> {
    return this.nationService.openPopup(NationFormComponent);
  }

}
