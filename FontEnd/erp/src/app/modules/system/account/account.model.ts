import { BaseViewModel } from '../../../core/models/base.model';

export interface AccountViewModel extends BaseViewModel {
  id: number;
  employeeId: number;
  employeeName: number;
  userName: number;
  roleName: string;
  password: number;
  lastLogin: Date;
}
