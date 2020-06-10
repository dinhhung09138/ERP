import { FormActionStatus } from '../enums/form-action-status.enum';

export class BaseViewModel {
  id: number;
  isActive: boolean;
  createDate: Date;
  createBy: number;
  updateDate: Date;
  updateBy: number;
  action: FormActionStatus;

  constructor() {
  }
}
