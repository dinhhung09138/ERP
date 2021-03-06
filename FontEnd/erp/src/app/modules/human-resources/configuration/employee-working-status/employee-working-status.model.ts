import { BaseViewModel } from 'src/app/core/models/base.model';

export interface EmployeeWorkingStatusViewModel extends BaseViewModel {
  code: string;
  name: string;
  description: string;
}
