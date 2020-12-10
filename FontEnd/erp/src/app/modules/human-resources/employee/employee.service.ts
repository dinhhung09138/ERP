import { Injectable } from '@angular/core';

import { switchMap } from 'rxjs/operators';
import { of, Observable } from 'rxjs';

import { ApiService } from 'src/app/core/services/api.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { EmployeeViewModel } from './employee.model';
import { PagingModel } from '../../../core/models/paging.model';
import { FormActionStatus } from '../../../core/enums/form-action-status.enum';
import { DialogService } from '../../../core/services/dialog.service';
import { PermissionViewModel } from '../../../core/models/permission.model';
import { SessionContext } from '../../../core/session.context';

@Injectable()
export class EmployeeService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_EMPLOYEE';
  personalInfoFunctionCode = 'HR_EMPLOYEE_PERSONAL_INFO';
  identificationFunctionCode = 'HR_EMPLOYEE_IDENTIFICATION';
  relationshipFunctionCode = 'HR_EMPLOYEE_RELATIONSHIP';
  educationFunctionCode = 'HR_EMPLOYEE_EDUCATION';
  certificateFunctionCode = 'HR_EMPLOYEE_CERTIFICATE';
  contactFunctionCode = 'HR_EMPLOYEE_CONTACT';
  bankFunctionCode = 'HR_EMPLOYEE_BANK';
  url = {
    list: APIUrlConstants.hrApi + 'employee/list',
    dropdown: APIUrlConstants.hrApi + 'employee/dropdown',
    dontHaveAccount: APIUrlConstants.hrApi + 'employee/dont-have-account',
    item: APIUrlConstants.hrApi + 'employee/item',
    insert: APIUrlConstants.hrApi + 'employee/insert',
    update: APIUrlConstants.hrApi + 'employee/update',
    delete: APIUrlConstants.hrApi + 'employee/delete',
  };

  constructor(
    private dialogService: DialogService,
    private api: ApiService,
    private context: SessionContext,
    ) { }

    getPermission(): PermissionViewModel {
      this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
      return this.permission;
    }

    getPersonalInfoPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.personalInfoFunctionCode);
    }

    getIdentificationPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.identificationFunctionCode);
    }

    getRelationshipPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.relationshipFunctionCode);
    }

    getEducationPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.educationFunctionCode);
    }

    getCertificatePermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.certificateFunctionCode);
    }

    getContactPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.contactFunctionCode);
    }

    getBankPermission(): PermissionViewModel {
      return this.context.getPermissionByForm(this.moduleName, this.bankFunctionCode);
    }

    getList(paging: PagingModel, searchText: string): Observable<ResponseModel> {
      const filter = new FilterModel();
      filter.text = searchText;
      filter.paging.pageIndex = paging.pageIndex;
      filter.paging.pageSize = paging.pageSize;

      return this.api.getListDataByFilterModel(this.url.list, filter);
    }

    item(id: number): Observable<ResponseModel> {
      return this.api.getDataById(this.url.item, id);
    }

    getDropdown(): Observable<ResponseModel> {
      return this.api.getListData(this.url.dropdown);
    }

    getEmployeeDontHaveAccount(): Observable<ResponseModel> {
      return this.api.getListData(this.url.dontHaveAccount);
    }

    save(model: EmployeeViewModel, action: FormActionStatus, file?: any): Observable<ResponseModel> {
      if (this.permission.allowInsert === false && this.permission.allowUpdate === false) {
        return;
      }
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
      if (model.currentPositionId) {
        formData.append('currentPositionId', model.currentPositionId.toString());
      }
      if (model.currentDepartmentId) {
        formData.append('currentDepartmentId', model.currentDepartmentId.toString());
      }
      if (model.basicSalary) {
        formData.append('basicSalary', model.basicSalary.toString());
      }

      if (file) {
        formData.append('file', file, file.name);
      }

      formData.append('rowVersion', model.rowVersion);

      switch (action) {
        case FormActionStatus.Insert:
          return this.api.insert(this.url.insert, formData);
        default:
          formData.append('id', model.id.toString());
          return this.api.updateFormData(this.url.update, formData);
      }
    }

    confirmDelete(itemId: number): Observable<ResponseModel> {
      if (this.permission.allowDelete === false) {
        return;
      }
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
      if (this.permission.allowDelete === false) {
        return;
      }
      return this.api.deleteById(this.url.delete, itemId);
    }
}
