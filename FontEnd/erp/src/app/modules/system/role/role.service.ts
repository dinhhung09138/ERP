import { Injectable } from '@angular/core';

import { of, Observable, BehaviorSubject } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { APIUrlConstants } from '../../../core/constants/api-url.constant';
import { FilterModel } from '../../../core/models/filter-table.model';
import { ResponseModel } from '../../../core/models/response.model';
import { ApiService } from 'src/app/core/services/api.service';
import { DialogService } from 'src/app/core/services/dialog.service';
import { PagingModel } from 'src/app/core/models/paging.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { RoleDetailViewModel } from './role-detail.model';
import { RoleViewModel } from './role.model';

@Injectable()
export class RoleService {

    private resetStatus$ = new BehaviorSubject(false);
    resetCommandInput = this.resetStatus$.asObservable();

    private roleDetail$ = new BehaviorSubject(new RoleViewModel());
    listRoleDetail = this.roleDetail$.asObservable();


    url = {
        list: APIUrlConstants.systemApi + 'role/get-list',
        dropdown: APIUrlConstants.systemApi + 'role/dropdown',
        item: APIUrlConstants.systemApi + 'role/item',
        insert: APIUrlConstants.systemApi + 'role/insert',
        update: APIUrlConstants.systemApi + 'role/update',
        delete: APIUrlConstants.systemApi + 'role/delete',
    };

    constructor(
        private api: ApiService,
        private dialogService: DialogService){}

    startResetCommandInputForm() {
      this.resetStatus$.next(true);
    }

    passingRoleDetailsData(data: RoleViewModel) {
      this.roleDetail$.next(data);
    }

    getList(paging: PagingModel, searchText: string){
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

    save(model: RoleViewModel, commands: RoleDetailViewModel[], action: FormActionStatus): Observable<ResponseModel> {
        model.roles = commands;
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
