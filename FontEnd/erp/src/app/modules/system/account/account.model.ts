import { BaseViewModel } from '../../../core/models/base.model';

export interface AccountViewModel extends BaseViewModel {
  id: number;
  employeeId: number;
  employeeName: number;
  userName: number;
  password: number;
  lastLogin: number;
}
