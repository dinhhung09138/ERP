import { Injectable } from '@angular/core';

import { switchMap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

import { SessionContext } from 'src/app/core/session.context';
import { PermissionViewModel } from './../../../../core/models/permission.model';
import { DialogService } from './../../../../core/services/dialog.service';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { ApiService } from './../../../../core/services/api.service';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { LeaveTypeViewModel } from './type.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class LeaveTypeService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_LEAVE_TYPE';
  url = {
    list: APIUrlConstants.hrApi + 'leave-type/list',
    item: APIUrlConstants.hrApi + 'leave-type/item',
    insert: APIUrlConstants.hrApi + 'leave-type/insert',
    update: APIUrlConstants.hrApi + 'leave-type/update',
    delete: APIUrlConstants.hrApi + 'leave-type/delete',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService,
    private context: SessionContext) { }

  getPermission(): PermissionViewModel {
    this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
    return this.permission;
  }

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

  save(model: LeaveTypeViewModel, action: FormActionStatus): Observable<ResponseModel> {
    if (this.permission.allowInsert === false && this.permission.allowUpdate === false) {
      return;
    }
    switch (action) {
      case FormActionStatus.Insert:
        return this.api.insert(this.url.insert, model);
      default:
        return this.api.update(this.url.update, model);
    }
  }

  confirmDelete(itemId: number, version: any): Observable<ResponseModel> {
    if (this.permission.allowDelete === false) {
      return;
    }
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
    if (this.permission.allowDelete === false) {
      return;
    }
    return this.api.delete(this.url.delete, {id: itemId, rowVersion: version });
  }
}
