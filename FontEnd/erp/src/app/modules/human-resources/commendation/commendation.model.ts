import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface CommendationViewModel extends BaseViewModel {
  name: string;
  description: string;
  money: number;
}
