import { BaseViewModel } from 'src/app/core/models/base.model';

export interface EmployeeViewModel extends BaseViewModel {
  employeeCode: string;
  firstName: string;
  lastName: string;
  fullName: string;
  probationDate: Date;
  startWorkingDate: Date;
  badgeCardNumber: string;
  dateApplyBadge: Date;
  fingerSignNumber: string;
  dateApplyFingerSign: Date;
  workingEmail: string;
  workingPhone: string;
  employeeWorkingStatusId: number;
  employeeWorkingStatusName: string;
  basicSalary: number;
  avatar: any;
  file: any;
}
