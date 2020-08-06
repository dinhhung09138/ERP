import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { PagingModel } from './../../../../core/models/paging.model';
import { ApiService } from './../../../../core/services/api.service';
import { DialogService } from './../../../../core/services/dialog.service';
import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { DistrictViewModel } from './district.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { MatDialog } from '@angular/material/dialog';
import { DistrictFormComponent } from './form/form.component';

@Injectable()
export class DistrictService {

  url = {
    list: APIUrlConstants.hrApi + 'district/get-list',
    dropdown: APIUrlConstants.hrApi + 'district/dropdown',
    item: APIUrlConstants.hrApi + 'district/item',
    insert: APIUrlConstants.hrApi + 'district/insert',
    update: APIUrlConstants.hrApi + 'district/update',
    delete: APIUrlConstants.hrApi + 'district/delete',
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

  save(model: DistrictViewModel, action: FormActionStatus): Observable<ResponseModel> {
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

  openPopupForm(): Observable<ResponseModel> {
    const dialogRef = this.dialog.open(DistrictFormComponent, {
      disableClose: true,
      data: {
        isPopup: true,
        title: 'Thêm mới Quận/Huyện'
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
