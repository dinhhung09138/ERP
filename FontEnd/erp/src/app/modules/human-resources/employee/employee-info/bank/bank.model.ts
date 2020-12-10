import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeBankViewModel extends BaseViewModel {
  employeeId: number;
  bankId: number;
  bankName: string;
  accountNumber: string;
  accountOwner: string;
  bankAddress: string;
}
