import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeRelationShipViewModel extends BaseViewModel {
  employeeId: number;
  fullName: string;
  relationshipTypeId: number;
  relationshipTypeName: string;
  address: string;
  mobile: string;
}
