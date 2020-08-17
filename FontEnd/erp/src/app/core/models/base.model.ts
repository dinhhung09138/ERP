import { FormActionStatus } from '../enums/form-action-status.enum';

export interface BaseViewModel {
  id: number;
  isActive: boolean;
  createDate: Date;
  createBy: number;
  updateDate: Date;
  updateBy: number;
  action: FormActionStatus;
  precedence: number;
  rowVersion: any;
}
