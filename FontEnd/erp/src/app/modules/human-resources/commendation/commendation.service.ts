import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { PagingModel } from './../../../core/models/paging.model';
import { DialogService } from './../../../core/services/dialog.service';
import { ApiService } from './../../../core/services/api.service';
import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { CommendationViewModel } from './commendation.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map, switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class CommendationService {

  url = {
    list: APIUrlConstants.hrApi + 'commendation/get-list',
    dropdown: APIUrlConstants.hrApi + 'commendation/dropdown',
    item: APIUrlConstants.hrApi + 'commendation/item',
    insert: APIUrlConstants.hrApi + 'commendation/insert',
    update: APIUrlConstants.hrApi + 'commendation/update',
    delete: APIUrlConstants.hrApi + 'commendation/delete',
  };

  constructor(
    private api: ApiService,
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

    save(model: CommendationViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
