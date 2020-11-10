import { CertificatedViewModel } from './../../modules/human-resources/configuration/certificated/certificated.model';
import { MajorViewModel } from './../../modules/human-resources/configuration/major/major.model';
import { SchoolViewModel } from './../../modules/human-resources/configuration/school/school.model';
import { ModelOfStudyViewModel } from '../../modules/human-resources/configuration/model-of-study/model-of-study.model';
import { RankingViewModel } from '../../modules/human-resources/configuration/ranking/ranking.model';
import { RelationshipTypeViewModel } from '../../modules/human-resources/configuration/relationship-type/relationship-type.model';
import { EducationViewModel } from '../../modules/human-resources/configuration/education/education.model';
import { HttpErrorStatusEnum } from '../enums/http-error.enum';
import { ProvinceViewModel } from '../../modules/human-resources/configuration/province/province.model';
import { IdentificationTypeViewModel } from '../../modules/human-resources/configuration/identification-type/identification-type.model';
import { DistrictViewModel } from '../../modules/human-resources/configuration/district/district.model';
import { WardViewModel } from '../../modules/human-resources/configuration/ward/ward.model';

export interface DialogDataViewModel {
  animal: string;
  title: string;
  message: string;
  isError: boolean;
  httpError: HttpErrorStatusEnum;
  isPopup: boolean;
  itemId: number;
  employeeId: number;
  listRelationShip: RelationshipTypeViewModel[];
  listMajor: MajorViewModel[];
  listSchool: SchoolViewModel[];
  listRank: RankingViewModel[];
  listModelOfStudy: ModelOfStudyViewModel[];
  listEducation: EducationViewModel[];
  listProvince: ProvinceViewModel[];
  listIdentificationType: IdentificationTypeViewModel[];
  listDistrict: DistrictViewModel[];
  listWard: WardViewModel[];
  listCertificated: CertificatedViewModel[];
}
