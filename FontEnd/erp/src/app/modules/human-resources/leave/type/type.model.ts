import { BaseViewModel } from '../../../../core/models/base.model';

export interface LeaveTypeViewModel extends BaseViewModel {
  code: string;
  name: string;
  numOfDay: number;
  isDeductible: boolean;
  description: string;
  startDate: number;
  expirationDate: number;
}
