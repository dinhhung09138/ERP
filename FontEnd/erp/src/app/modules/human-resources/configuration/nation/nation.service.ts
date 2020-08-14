import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { PagingModel } from './../../../../core/models/paging.model';
import { Injectable } from '@angular/core';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { NationViewModel } from './nation.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map, switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { MatDialog } from '@angular/material/dialog';

@Injectable()
export class NationService {

  url = {
    list: APIUrlConstants.hrApi + 'nation/get-list',
    dropdown: APIUrlConstants.hrApi + 'nation/dropdown',
    item: APIUrlConstants.hrApi + 'nation/item',
    insert: APIUrlConstants.hrApi + 'nation/insert',
    update: APIUrlConstants.hrApi + 'nation/update',
    delete: APIUrlConstants.hrApi + 'nation/delete',
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

  openPopup(form: any): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(form, {
      width: '500px',
      disableClose: true,
      data: {
        isPopup: true,
        title: 'Thêm dân tộc mới'
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
    return this.api.item(this.url.item, id);
  }

  getDropdown() {
    return this.api.getDropdown(this.url.dropdown);
  }

  save(model: NationViewModel, action: FormActionStatus): Observable<ResponseModel> {
    switch (action) {
      case FormActionStatus.Insert:
        return this.api.insert(this.url.insert, model);
      default:
        return this.api.update(this.url.update, model);
    }
  }

  confirmDelete(itemId: number): Observable<ResponseModel> {
    return this.dialogService.openConfirmDeleteDialog().pipe(
      switchMap((confirmResponse: boolean) => {
        if (confirmResponse === true) {
          return this.delete(itemId);
        } else {
          return of(null);
        }
      })
    );
  }

  delete(itemId: number): Observable<ResponseModel> {
    return this.api.deleteById(this.url.delete, itemId);
  }
}
