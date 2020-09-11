import { BaseViewModel } from 'src/app/core/models/base.model';

export interface WardViewModel extends BaseViewModel {
  name: string;
  districtId: number;
  districtName: string;
  provinceId: number;
  provinceName: string;
}
