import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeIdentificationViewModel extends BaseViewModel {
  employeeId: number;
  code: string;
  name: string;
  placeId: number;
  placeName: string;
  identificationTypeId: number;
  identificationTypeName: string;
  notes: string;
  applyDate: Date;
  expirationDate: Date;
}
