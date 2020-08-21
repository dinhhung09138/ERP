import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/core/services/api.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { switchMap } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { EmployeeViewModel } from './employee.model';
import { PagingModel } from '../../../core/models/paging.model';
import { FormActionStatus } from '../../../core/enums/form-action-status.enum';
import { DialogService } from '../../../core/services/dialog.service';

@Injectable()
export class EmployeeService {

  url = {
    list: APIUrlConstants.hrApi + 'employee/get-list',
    dropdown: APIUrlConstants.hrApi + 'employee/dropdown',
    item: APIUrlConstants.hrApi + 'employee/item',
    insert: APIUrlConstants.hrApi + 'employee/insert',
    update: APIUrlConstants.hrApi + 'employee/update',
    delete: APIUrlConstants.hrApi + 'employee/delete',
  };

  constructor(
    private dialogService: DialogService,
    private api: ApiService) { }

    getList(paging: PagingModel, searchText: string): Observable<ResponseModel> {
      const filter = new FilterModel();
      filter.text = searchText;
      filter.paging.pageIndex = paging.pageIndex;
      filter.paging.pageSize = paging.pageSize;

      return this.api.getList(this.url.list, filter);
    }

    item(id: number): Observable<ResponseModel> {
      return this.api.item(this.url.item, id);
    }

    getDropdown(): Observable<ResponseModel> {
      return this.api.getDropdown(this.url.dropdown);
    }

    save(model: EmployeeViewModel, action: FormActionStatus, file?: any): Observable<ResponseModel> {
      const formData = new FormData();

      formData.append('employeeCode', model.employeeCode);
      formData.append('firstName', model.firstName);
      formData.append('lastName', model.lastName);
      if (model.probationDate) {
        formData.append('probationDate', model.probationDate.toUTCString());
      }
      if (model.startWorkingDate) {
        formData.append('startWorkingDate', model.startWorkingDate.toUTCString());
      }
      formData.append('badgeCardNumber', model.badgeCardNumber);
      if (model.dateApplyBadge) {
        formData.append('dateApplyBadge', model.dateApplyBadge.toUTCString());
      }
      formData.append('fingerSignNumber', model.fingerSignNumber);
      if (model.dateApplyFingerSign) {
        formData.append('dateApplyFingerSign', model.dateApplyFingerSign.toUTCString());
      }
      formData.append('workingEmail', model.workingEmail);
      formData.append('workingPhone', model.workingPhone);
      if (model.employeeWorkingStatusId) {
        formData.append('employeeWorkingStatusId', model.employeeWorkingStatusId.toString());
      }
      if (model.basicSalary) {
        formData.append('basicSalary', model.basicSalary.toString());
      }

      if (file) {
        formData.append('file', file, file.name);
      }

      console.log(formData);

      switch (action) {
        case FormActionStatus.Insert:
          return this.api.insert(this.url.insert, formData);
        default:
          formData.append('id', model.id.toString());
          return this.api.updateFormData(this.url.update, formData);
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
