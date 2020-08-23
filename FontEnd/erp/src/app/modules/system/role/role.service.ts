import { Injectable } from "@angular/core";
import { APIUrlConstants } from '../../../core/constants/api-url.constant';
import { FilterModel } from '../../../core/models/filter-table.model';
import { ResponseModel } from '../../../core/models/response.model';
import { of, Observable } from "rxjs";
import { RoleViewModel } from "./role.model";
import { ApiService } from 'src/app/core/services/api.service';
import { DialogService } from 'src/app/core/services/dialog.service';
import { PagingModel } from 'src/app/core/models/paging.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { switchMap } from 'rxjs/operators';


@Injectable()
export class RoleService {
    url={
        list: APIUrlConstants.system + 'role/get-list',
        dropdown: APIUrlConstants.system + 'role/dropdown',
        item: APIUrlConstants.system + 'role/item',
        insert: APIUrlConstants.system + 'role/insert',
        update: APIUrlConstants.system + 'role/update',
        delete: APIUrlConstants.system + 'role/delete',
    };
    constructor(
        private api: ApiService,
        private dialogService: DialogService){}

    getList(paging:PagingModel,searchText: string){
        const filter = new FilterModel();
        filter.text = searchText;
        filter.paging.pageIndex = paging.pageIndex;
        filter.paging.pageSize = paging.pageSize;
        return this.api.getList(this.url.list, filter);
    }
    getDropdown(){
        return this.api.getDropdown(this.url.dropdown);
    }
    item(id:number){
        return this.api.item(this.url.item,id);
    }
    save(model: RoleViewModel, action: FormActionStatus): Observable<ResponseModel> {
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