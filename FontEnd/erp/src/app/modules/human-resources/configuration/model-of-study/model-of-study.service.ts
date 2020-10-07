import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { SessionContext } from 'src/app/core/session.context';
import { PermissionViewModel } from './../../../../core/models/permission.model';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { ModelOfStudyViewModel } from './model-of-study.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class ModelOfStudyService {

  moduleName = 'HR';
  functionCode = 'HR_CONF_MODEL_OF_STUDY';
  url = {
    list: APIUrlConstants.hrApi + 'model-of-study/get-list',
    dropdown: APIUrlConstants.hrApi + 'model-of-study/dropdown',
    item: APIUrlConstants.hrApi + 'model-of-study/item',
    insert: APIUrlConstants.hrApi + 'model-of-study/insert',
    update: APIUrlConstants.hrApi + 'model-of-study/update',
    delete: APIUrlConstants.hrApi + 'model-of-study/delete',
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

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  save(model: ModelOfStudyViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
