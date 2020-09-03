import { Injectable } from '@angular/core';
import { APIUrlConstants } from '../../../core/constants/api-url.constant';
import { ApiService } from '../../../core/services/api.service';

@Injectable()
export class FunctionService {

  url = {
    getAll: APIUrlConstants.systemApi + 'function/get-all-function',
  };

  constructor(private api: ApiService) {}

  getAllFunctions() {
    return this.api.getListData(this.url.getAll);
  }

}
