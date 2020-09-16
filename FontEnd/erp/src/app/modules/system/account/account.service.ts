import { switchMap } from 'rxjs/operators';
import { Injectable } from '@angular/core';

import { EMPTY, Observable, of } from 'rxjs';

import { DialogService } from './../../../core/services/dialog.service';
import { AccountViewModel } from './account.model';
import { ResponseModel } from './../../../core/models/response.model';
import { FilterModel } from './../../../core/models/filter-table.model';
import { PagingModel } from './../../../core/models/paging.model';
import { APIUrlConstants } from './../../../core/constants/api-url.constant';
import { ApiService } from '../../../core/services/api.service';


@Injectable()
export class AccountService {

  url = {
    list: APIUrlConstants.systemApi + 'user/get-list',
    insert: APIUrlConstants.systemApi + 'user/insert',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService) {
  }

  getList(paging: PagingModel, searchText: string): Observable<ResponseModel> {
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    return this.api.getListDataByFilterModel(this.url.list, filter);
  }

  insert(model: AccountViewModel): Observable<ResponseModel> {
    return this.api.insert(this.url.insert, model);
  }

  confirmActiveOrDeactivation(isActive: boolean): Observable<ResponseModel | any> {
    return this.dialogService.openConfirmDeleteDialog().pipe(
      switchMap((confirmResponse: boolean) => {
        if (confirmResponse === true) {
          return of(new ResponseModel());
        } else {
          return of(EMPTY);
        }
      })
    );
  }

}
