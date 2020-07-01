import { BaseViewModel } from 'src/app/core/models/base.mode';

export interface DisciplineViewModel extends BaseViewModel {
  name: string;
  provinceId: number;
  provinceName: string;
  money: number;
}
