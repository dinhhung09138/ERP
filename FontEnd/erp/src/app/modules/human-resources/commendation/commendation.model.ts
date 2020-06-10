import { BaseViewModel } from 'src/app/core/models/base.mode';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';

export class CommendationViewModel extends BaseViewModel {
  name: string;
  description: string;
  money: number;


  constructor() {
    super();
  }
}
