import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface ContractTypeViewModel extends BaseViewModel {
  code: string;
  name: string;
  description: number;
  allowInsurance: boolean;
  allowLeaveDay: boolean;
}
