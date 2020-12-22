import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeDependencyViewModel extends BaseViewModel {
  employeeId: number;
  fullName: string;
  relationshipTypeId: number;
  relationshipTypeName: string;
  dateOfBirth: string;
  age: number;
}
