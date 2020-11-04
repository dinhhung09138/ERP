import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { ApiService } from '../../../../../core/services/api.service';
import { DialogService } from '../../../../../core/services/dialog.service';
import { SessionContext } from '../../../../../core/session.context';
import { PagingModel } from '../../../../../core/models/paging.model';
import { FilterModel } from '../../../../../core/models/filter-table.model';
import { ResponseModel } from '../../../../../core/models/response.model';
import { FormActionStatus } from '../../../../../core/enums/form-action-status.enum';
import { EmployeeIdentificationViewModel } from './identification.model';

@Injectable()
export class EmployeeIdentificationService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_EMPLOYEE_IDENTIFICATION';
  url = {
    list: APIUrlConstants.hrApi + 'employee-identification/get-list',
    item: APIUrlConstants.hrApi + 'employee-identification/item',
    insert: APIUrlConstants.hrApi + 'employee-identification/insert',
    update: APIUrlConstants.hrApi + 'employee-identification/update',
    delete: APIUrlConstants.hrApi + 'employee-identification/delete',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService,
    private context: SessionContext
  ) {}

  getPermission(): PermissionViewModel {
    this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
    return this.permission;
  }

  getList(paging: PagingModel, searchText: string, employeeId: number): Observable<ResponseModel> {
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;
    filter.employeeId = employeeId;

    return this.api.getListDataByFilterModel(this.url.list, filter);
  }

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  save(model: EmployeeIdentificationViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
    return this.api.delete(this.url.delete, {id: itemId, rowVersion: version});
  }

}
