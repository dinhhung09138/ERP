import { BaseViewModel } from '../../../../../core/models/base.model';

export interface EmployeeContactViewModel extends BaseViewModel {
  phone: string;
  mobile: string;
  email: string;
  skype: string;
  temporaryAddress: string;
  temporaryProvinceId: number;
  permanentAddress: string;
  permanentProvinceId: number;
  facebook: string;
  github: string;
  linkedIn: string;
  twitter: string;
  zalo: string;
}
