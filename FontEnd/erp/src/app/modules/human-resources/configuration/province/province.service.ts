import { ApiService } from './../../../../core/services/api.service';
import { DialogService } from './../../../../core/services/dialog.service';
import { PagingModel } from './../../../../core/models/paging.model';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { Injectable } from '@angular/core';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { ProvinceViewModel } from './province.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { MatDialog } from '@angular/material/dialog';

@Injectable()
export class ProvinceService {

  url = {
    list: APIUrlConstants.hrApi + 'province/get-list',
    dropdown: APIUrlConstants.hrApi + 'province/dropdown',
    item: APIUrlConstants.hrApi + 'province/item',
    insert: APIUrlConstants.hrApi + 'province/insert',
    update: APIUrlConstants.hrApi + 'province/update',
    delete: APIUrlConstants.hrApi + 'province/delete',
  };

  constructor(
    private api: ApiService,
    private dialog: MatDialog,
    private dialogService: DialogService) { }

  getList(paging: PagingModel, searchText: string) {
    const filter = new FilterModel();
    filter.text = searchText;
    filter.paging.pageIndex = paging.pageIndex;
    filter.paging.pageSize = paging.pageSize;

    return this.api.getList(this.url.list, filter);
  }

  item(id: number) {
    return this.api.item(this.url.item, id);
  }

  getDropdown() {
    return this.api.getDropdown(this.url.dropdown);
  }

  save(model: ProvinceViewModel, action: FormActionStatus): Observable<ResponseModel> {
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

  openPopupForm(form: any): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(form, {
      width: '500px',
      disableClose: true,
      data: {
        isPopup: true,
        title: 'SCREEN.HR.CONFIGURATION.PROVINCE.POPUP_TITLE'
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
}
