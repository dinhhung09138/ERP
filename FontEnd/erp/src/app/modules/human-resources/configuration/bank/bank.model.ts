import { BaseViewModel } from 'src/app/core/models/base.model';

export interface BankViewModel extends BaseViewModel {
  code: string;
  name: string;
}
