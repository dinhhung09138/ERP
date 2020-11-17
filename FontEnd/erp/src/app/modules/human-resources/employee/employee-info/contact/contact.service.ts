import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { ResponseModel } from '../../../../../core/models/response.model';
import { EmployeeContactViewModel } from './contact.model';
import { APIUrlConstants } from '../../../../../core/constants/api-url.constant';
import { SessionContext } from '../../../../../core/session.context';
import { ApiService } from '../../../../../core/services/api.service';
import { ProvinceService } from '../../../configuration/province/province.service';


@Injectable()
export class EmployeeContactService {

  permission = new PermissionViewModel();
  moduleName = 'HR';
  functionCode = 'HR_EMPLOYEE_CONTACT';

  constructor(
    private http: HttpClient,
    private api: ApiService,
    private provinceService: ProvinceService,
    private context: SessionContext) { }

  url = {
    item: APIUrlConstants.hrApi + 'employee-contact/item',
    itemByEmployeeId: APIUrlConstants.hrApi + 'employee-contact/item-by-employee',
    update: APIUrlConstants.hrApi + 'employee-contact/update',
  };

  getPermission(): PermissionViewModel {
    this.permission = this.context.getPermissionByForm(this.moduleName, this.functionCode);
    return this.permission;
  }

  item(id: number): Observable<ResponseModel> {
    return this.api.getDataById(this.url.item, id);
  }

  getInfoByEmployeeId(employeeId: number): Observable<ResponseModel> {
    console.log('call here');
    return this.http.get(this.url.itemByEmployeeId + '?employeeId=' + employeeId).pipe(
      map((response: ResponseModel) => {
        return response;
      })
    );
  }

  save(model: EmployeeContactViewModel): Observable<ResponseModel> {
    if (this.permission.allowUpdate === false) {
      return;
    }
    return this.api.update(this.url.update, model);
  }

  getSelection(): Observable<any> {
    return forkJoin([
      this.provinceService.getDropdown(),
    ]).pipe(
      map(
        ([provinceData]) => {
          return {
            provinces: provinceData
          };
        }
      )
    );
  }
}
