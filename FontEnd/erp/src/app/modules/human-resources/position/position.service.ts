import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { PagingModel } from './../../../core/models/paging.model';
import { DialogService } from './../../../core/services/dialog.service';
import { ApiService } from './../../../core/services/api.service';
import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { PositionViewModel } from './position.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map, switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class PositionService {

  url = {
    list: APIUrlConstants.hrApi + 'position/get-list',
    dropdown: APIUrlConstants.hrApi + 'position/dropdown',
    item: APIUrlConstants.hrApi + 'position/item',
    insert: APIUrlConstants.hrApi + 'position/insert',
    update: APIUrlConstants.hrApi + 'position/update',
    delete: APIUrlConstants.hrApi + 'position/delete',
  };

  constructor(
    private api: ApiService,
    private dialogService: DialogService) { }

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

    save(model: PositionViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
      return this.api.delete(this.url.delete, { id: itemId, rowVersion: version });
    }
}
