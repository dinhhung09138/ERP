import { BaseViewModel } from '../../../../core/models/base.model';

export interface LeaveStatusViewModel extends BaseViewModel {
  name: string;
  typed: number;
  typeName: string;
}
