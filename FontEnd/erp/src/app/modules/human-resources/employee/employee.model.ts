import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface EmployeeViewModel extends BaseViewModel {
  employeeCode: string;
  firstName: string;
  lastName: string;
  probationDate: Date;
  startWorkingDate: Date;
  badgeCardNumber: string;
  dateApplyBadge: Date;
  fingerSignNumber: string;
  dateApplyFingerSign: Date;
  workingEmail: string;
  workingPhone: string;
  employeeWorkingStatusId: number;
  basicSalary: number;
}
