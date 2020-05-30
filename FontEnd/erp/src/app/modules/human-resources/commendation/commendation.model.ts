import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface CommendationViewModal extends BaseViewModel {
  name: string;
  description: string;
  money: number;
}
