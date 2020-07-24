import { BaseViewModel } from 'src/app/core/models/base.model';

export interface DistrictViewModel extends BaseViewModel {
  name: string;
  provinceId: number;
}
