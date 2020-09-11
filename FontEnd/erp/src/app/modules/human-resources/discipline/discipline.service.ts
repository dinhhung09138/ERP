import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { DialogService } from './../../../core/services/dialog.service';
import { ApiService } from './../../../core/services/api.service';
import { PagingModel } from './../../../core/models/paging.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { DisciplineViewModel } from './discipline.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class DisciplineService {

  url = {
    list: APIUrlConstants.hrApi + 'discipline/get-list',
    dropdown: APIUrlConstants.hrApi + 'discipline/dropdown',
    item: APIUrlConstants.hrApi + 'discipline/item',
    insert: APIUrlConstants.hrApi + 'discipline/insert',
    update: APIUrlConstants.hrApi + 'discipline/update',
    delete: APIUrlConstants.hrApi + 'discipline/delete',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService) { }

  getList(paging: PagingModel, searchText: string) {
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;

    return this.api.getListDataByFilterModel(this.url.list, filter);
  }

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  save(model: DisciplineViewModel, action: FormActionStatus): Observable<ResponseModel> {
    switch (action) {
      case FormActionStatus.Insert:
        return this.api.insert(this.url.insert, model);
      default:
        return this.api.update(this.url.update, model);
    }
  }

  confirmDelete(itemId: number, version: any): Observable<ResponseModel> {
    return this.dialogService.openConfirmDeleteDialog().pipe(
      switchMap((confirmResponse: boolean) => {
        if (confirmResponse === true) {
          return this.delete(itemId, version);
        } else {
          return of(null);
        }
      })
    );
  }

  delete(itemId: number, version: any): Observable<ResponseModel> {
    return this.api.delete(this.url.delete, { id: itemId, rowVersion: version });
  }
}
