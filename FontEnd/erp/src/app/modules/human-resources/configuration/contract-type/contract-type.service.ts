import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { SessionContext } from 'src/app/core/session.context';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { ApiService } from './../../../../core/services/api.service';
import { DialogService } from './../../../../core/services/dialog.service';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { ContractTypeViewModel } from './contract-type.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { PermissionViewModel } from '../../../../core/models/permission.model';

@Injectable()
export class ContractTypeService {

  moduleName = 'HR';
  functionCode = 'HR_CONF_CONTRACT';
  url = {
    list: APIUrlConstants.hrApi + 'contract-type/get-list',
    dropdown: APIUrlConstants.hrApi + 'contract-type/dropdown',
    item: APIUrlConstants.hrApi + 'contract-type/item',
    insert: APIUrlConstants.hrApi + 'contract-type/insert',
    update: APIUrlConstants.hrApi + 'contract-type/update',
    delete: APIUrlConstants.hrApi + 'contract-type/delete',
  };


  constructor(
    private api: ApiService,
    private dialogService: DialogService,
    private context: SessionContext) { }

  getPermission(): PermissionViewModel {
    return this.context.getPermissionByForm(this.moduleName, this.functionCode);
  }

  getList(paging: PagingModel, searchText: string) {
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;

    return this.api.getListDataByFilterModel(this.url.list, filter);
  }

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  save(model: ContractTypeViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
