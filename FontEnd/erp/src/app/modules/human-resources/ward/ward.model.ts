import { BaseViewModel } from 'src/app/core/models/base.mode';
import { ProvinceViewModel } from '../province/province.model';
import { DistrictViewModel } from '../district/district.model';

export interface WardViewModel extends BaseViewModel {
  name: string;
  districtId: number;
  districtName: string;
  provinceId: number;
  provinceName: string;
}
