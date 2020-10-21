import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeEducationViewModel extends BaseViewModel {
  employeeId: number;
  educationTypeId: number;
  school: string;
  majorId: number;
  majorName: string;
  rankingId: number;
  rankingName: string;
  modelOfStudyId: number;
  modelOfStudyName: string;
  year: number;
}
