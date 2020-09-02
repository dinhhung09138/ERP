import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, map, switchMap } from 'rxjs/operators';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeWorkingStatusViewModel } from './employee-working-status.model';

@Injectable()
export class EmployeeWorkingStatusService {

  url = {
    list: APIUrlConstants.hrApi + 'employee-working-status/get-list',
    dropdown: APIUrlConstants.hrApi + 'employee-working-status/dropdown',
    item: APIUrlConstants.hrApi + 'employee-working-status/item',
    insert: APIUrlConstants.hrApi + 'employee-working-status/insert',
    update: APIUrlConstants.hrApi + 'employee-working-status/update',
    delete: APIUrlConstants.hrApi + 'employee-working-status/delete',
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

  save(model: EmployeeWorkingStatusViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
    return this.api.delete(this.url.delete, {id: itemId, rowVersion: version });
  }
}
