import { BaseViewModel } from 'src/app/core/models/base.model';

export interface TrainingCenterViewModel extends BaseViewModel {
  name: string;
  avatar: string;
  taxCode: string;
  phone: string;
  description: string;
}
