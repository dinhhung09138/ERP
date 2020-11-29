import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';

import { SessionContext } from 'src/app/core/session.context';
import { PermissionViewModel } from './../../../../core/models/permission.model';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { ApiService } from './../../../../core/services/api.service';
import { DialogService } from './../../../../core/services/dialog.service';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { DistrictViewModel } from './district.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ProvinceService } from '../province/province.service';
import { ResponseStatus } from '../../../../core/enums/response-status.enum';
import { ProvinceViewModel } from '../province/province.model';


@Injectable()
export class DistrictService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_CONF_DISTRICT';
  url = {
    list: APIUrlConstants.commonApi + 'district/list',
    dropdown: APIUrlConstants.commonApi + 'district/dropdown',
    item: APIUrlConstants.commonApi + 'district/item',
    insert: APIUrlConstants.commonApi + 'district/insert',
    update: APIUrlConstants.commonApi + 'district/update',
    delete: APIUrlConstants.commonApi + 'district/delete',
  };

  constructor(
    private api: ApiService,
    private dialog: MatDialog,
    private dialogService: DialogService,
    private context: SessionContext,
    private provinceService: ProvinceService) { }

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

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  save(model: DistrictViewModel, action: FormActionStatus): Observable<ResponseModel> {
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

  openPopupForm(form: any): Observable<ResponseModel> {
    let provinceData = null;
    this.provinceService.getDropdown().toPromise().then((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        provinceData = response.result;
      }
    });

    const dialogRef = this.dialog.open(form, {
      panelClass: 'mat-modal-sm',
      disableClose: true,
      data: {
        listProvince: provinceData
      }
    });
    return dialogRef.beforeClosed().pipe(
      switchMap((result: boolean) => {
        if (result === true) {
          return this.getDropdown();
        } else {
          return of(null);
        }
      })
    );
  }
}
