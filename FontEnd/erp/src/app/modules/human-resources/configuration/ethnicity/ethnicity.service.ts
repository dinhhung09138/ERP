import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { PagingModel } from './../../../../core/models/paging.model';
import { Injectable } from '@angular/core';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { EthnicityViewModel } from './ethnicity.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map, switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { MatDialog } from '@angular/material/dialog';

@Injectable()
export class EthnicityService {

  url = {
    list: APIUrlConstants.hrApi + 'ethnicity/get-list',
    dropdown: APIUrlConstants.hrApi + 'ethnicity/dropdown',
    item: APIUrlConstants.hrApi + 'ethnicity/item',
    insert: APIUrlConstants.hrApi + 'ethnicity/insert',
    update: APIUrlConstants.hrApi + 'ethnicity/update',
    delete: APIUrlConstants.hrApi + 'ethnicity/delete',
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

    return this.api.getListDataByFilterModel(this.url.list, filter);
  }

  openPopup(form: any): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(form, {
      width: '500px',
      disableClose: true,
      data: {
        isPopup: true,
        title: 'SCREEN.HR.CONFIGURATION.ETHNICITY.POPUP_TITLE'
      },
    });

    return dialogRef.beforeClosed().pipe(
      switchMap((result: boolean) => {
        if (result === true) {
          return this.getDropdown();
        } else {
          return of(null);
        }
      })
    )
  }

  item(id: number) {
    return this.api.getDataById(this.url.item, id);
  }

  getDropdown() {
    return this.api.getListData(this.url.dropdown);
  }

  save(model: EthnicityViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
