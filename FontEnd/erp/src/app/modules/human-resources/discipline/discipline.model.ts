import { BaseViewModel } from 'src/app/core/models/base.model';

export interface DisciplineViewModel extends BaseViewModel {
  name: string;
  description: string;
  money: number;
}
