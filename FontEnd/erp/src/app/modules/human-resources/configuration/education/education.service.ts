import { Injectable } from '@angular/core';

import { Observable, of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';

import { SessionContext } from 'src/app/core/session.context';
import { PermissionViewModel } from './../../../../core/models/permission.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { EducationViewModel } from './education.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { PagingModel } from './../../../../core/models/paging.model';
import { ApiService } from './../../../../core/services/api.service';
import { DialogService } from './../../../../core/services/dialog.service';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';

@Injectable()
export class EducationService {

  moduleName = 'HR';
  functionCode = 'HR_CONF_EDUCATION';
  url = {
    list: APIUrlConstants.hrApi + 'education/get-list',
    dropdown: APIUrlConstants.hrApi + 'education/dropdown',
    item: APIUrlConstants.hrApi + 'education/item',
    insert: APIUrlConstants.hrApi + 'education/insert',
    update: APIUrlConstants.hrApi + 'education/update',
    delete: APIUrlConstants.hrApi + 'education/delete',
  };

  constructor(
    private api: ApiService,
    private dialog: MatDialog,
    private dialogService: DialogService,
    private context: SessionContext) { }

  getPermission(): PermissionViewModel {
    return this.context.getPermissionByForm(this.moduleName, this.functionCode);
  }

  openPopupForm(form: any): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(form, {
      width: '500px',
      disableClose: true,
      data: {
        isPopup: true,
        title: 'SCREEN.HR.CONFIGURATION.EDUCATION.POPUP_TITLE',
      }
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

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  save(model: EducationViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
