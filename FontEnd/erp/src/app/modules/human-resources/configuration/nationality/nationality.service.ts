import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';

import { SessionContext } from 'src/app/core/session.context';
import { PermissionViewModel } from './../../../../core/models/permission.model';
import { PagingModel } from './../../../../core/models/paging.model';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { NationalityViewModel } from './nationality.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class NationalityService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_CONF_NATIONALITY';
  url = {
    list: APIUrlConstants.hrApi + 'nationality/list',
    dropdown: APIUrlConstants.hrApi + 'nationality/dropdown',
    item: APIUrlConstants.hrApi + 'nationality/item',
    insert: APIUrlConstants.hrApi + 'nationality/insert',
    update: APIUrlConstants.hrApi + 'nationality/update',
    delete: APIUrlConstants.hrApi + 'nationality/delete',
  };

  constructor(
    private api: ApiService,
    private dialog: MatDialog,
    private dialogService: DialogService,
    private context: SessionContext) { }

  getPermission(): PermissionViewModel {
    this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
    return this.permission;
  }

  openPopupForm(form: any): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(form, {
      panelClass: 'mat-modal-sm',
      disableClose: true,
      data: {
        isPopup: true,
      },
    });

    return dialogRef.beforeClosed().pipe(
      switchMap((data: boolean) => {
        if (data === true) {
          return this.getDropdown();
        } else {
          return of(null);
        }
      })
    );
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

  save(model: NationalityViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
