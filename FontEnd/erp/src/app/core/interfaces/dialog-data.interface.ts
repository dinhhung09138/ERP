import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { ProvinceViewModel } from '../../modules/human-resources/configuration/province/province.model';
import { IdentificationTypeViewModel } from '../../modules/human-resources/configuration/identification-type/identification-type.model';

export interface DialogDataInterface {
  animal: string;
  title: string;
  message: string;
  isError: boolean;
  httpError: HttpErrorStatusEnum;
  isPopup: boolean;
  itemId: number;
  employeeId: number;
  listRelationShip: any[];
  listProvince: ProvinceViewModel[];
  listIdentificationType: IdentificationTypeViewModel[];
}
