import { PagingModel } from './paging.model';

export class FilterModel {
  text: string;
  paging: PagingModel;

  constructor() {
    this.text = '';
    this.paging = new PagingModel();
  }
}
