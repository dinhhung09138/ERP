import { BaseViewModel } from 'src/app/core/models/base.model';

export interface ContractTypeViewModel extends BaseViewModel {
  code: string;
  name: string;
  description: number;
  allowInsurance: boolean;
  allowLeaveDate: boolean;
}
