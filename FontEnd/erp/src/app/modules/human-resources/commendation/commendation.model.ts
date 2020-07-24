import { BaseViewModel } from 'src/app/core/models/base.model';

export interface CommendationViewModel extends BaseViewModel {
  name: string;
  description: string;
  money: number;
}
