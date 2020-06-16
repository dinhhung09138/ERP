import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface DistrictViewModel extends BaseViewModel {
  name: string;
  description: string;
  money: number;
}
