import { PagingModel } from './../../../../core/models/paging.model';
import { DialogService } from './../../../../core/services/dialog.service';
import { ApiService } from './../../../../core/services/api.service';
import { FormActionStatus } from './../../../../core/enums/form-action-status.enum';
import { Injectable } from '@angular/core';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { IdentificationTypeViewModel } from './identification-type.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { switchMap } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class IdentificationTypeService {

  url = {
    list: APIUrlConstants.hrApi + 'identification-type/get-list',
    dropdown: APIUrlConstants.hrApi + 'identification-type/dropdown',
    item: APIUrlConstants.hrApi + 'identification-type/item',
    insert: APIUrlConstants.hrApi + 'identification-type/insert',
    update: APIUrlConstants.hrApi + 'identification-type/update',
    delete: APIUrlConstants.hrApi + 'identification-type/delete',
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

  save(model: IdentificationTypeViewModel, action: FormActionStatus): Observable<ResponseModel> {
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
