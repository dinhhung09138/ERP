import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { SessionContext } from '../../../../../core/session.context';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { ApiService } from '../../../../../core/services/api.service';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { DialogService } from '../../../../../core/services/dialog.service';
import { PagingModel } from '../../../../../core/models/paging.model';
import { FilterModel } from '../../../../../core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeRelationShipViewModel } from './relationship.model';
import { FormActionStatus } from '../../../../../core/enums/form-action-status.enum';

@Injectable()
export class EmployeeRelationShipService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_EMPLOYEE_RELATIONSHIP';
  url = {
    list: APIUrlConstants.hrApi + 'employee-relationship/get-list',
    item: APIUrlConstants.hrApi + 'employee-relationship/item',
    insert: APIUrlConstants.hrApi + 'employee-relationship/insert',
    update: APIUrlConstants.hrApi + 'employee-relationship/update',
    delete: APIUrlConstants.hrApi + 'employee-relationship/delete',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService,
    private context: SessionContext,
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

  save(model: EmployeeRelationShipViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
