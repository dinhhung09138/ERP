import { BaseViewModel } from '../../../../../core/models/base.model';

export interface PersonalInfoViewModel extends BaseViewModel {
  id: number;
  employeeId: number;
  firstName: string;
  lastName: string;
  gender?: boolean;
  dateOfBirth: Date;
  materialStatusId: number;
  religionId: number;
  ethnicityId: number;
  nationalityId: number;
  academicLevelId: number;
  professionalQualificationId: number;
  expirationDate: Date;
}

