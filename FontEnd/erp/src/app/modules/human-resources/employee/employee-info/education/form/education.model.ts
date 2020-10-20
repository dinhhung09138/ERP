import { BaseViewModel } from './../../../../../../core/models/base.model';

export interface EmployeeEducationViewModel extends BaseViewModel {
  employeeId: number;
  schoolId: number;
  specializedTrainingId: number;
  year: number;
  trainingTypeId: number;
  rankingId: number;
  modelOfStudyId: number;
}
