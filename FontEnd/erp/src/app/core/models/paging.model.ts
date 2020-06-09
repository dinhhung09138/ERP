import { PagingConstants } from '../constants/paging.constant';

export class PagingModel {
  pageSize: number;
  pageIndex: number;

  constructor() {
    this.pageSize = PagingConstants.pageSize;
    this.pageIndex = 0;
  }
}
