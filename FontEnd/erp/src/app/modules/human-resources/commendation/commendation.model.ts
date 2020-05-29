import { BaseViewModel } from 'src/app/core/models/base.mode';

export class CommendationViewModal extends BaseViewModel {
  name: string;
  description: string;
  money: number;

  constructor() {
    super();
    this.name = '';
    this.description = '';
    this.money = null;
  }
}
