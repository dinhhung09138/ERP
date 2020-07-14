import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface EmployeeWorkingStatusViewModel extends BaseViewModel {
  code: string;
  name: string;
  description: string;
}
