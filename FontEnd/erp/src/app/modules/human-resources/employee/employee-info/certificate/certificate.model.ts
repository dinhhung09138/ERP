import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeCertificateViewModel extends BaseViewModel {
  employeeId: number;
  certificateId: number;
  certificateName: string;
  schoolId: number;
  schoolName: string;
  year: number;
}
