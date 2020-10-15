import { PagingModel } from './paging.model';

export class FilterModel {
  text: string;
  paging: PagingModel;
  employeeId: number;
  constructor() {
    this.text = '';
    this.paging = new PagingModel();
    this.employeeId = 0;
  }
}
