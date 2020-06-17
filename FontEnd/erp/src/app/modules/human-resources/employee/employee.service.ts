import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { EmployeeViewModel } from './employee.model';

@Injectable()
export class EmployeeService {

  url = {
    list: APIUrlConstants.hrApi + 'employee/get-list',
    dropdown: APIUrlConstants.hrApi + 'employee/dropdown',
    item: APIUrlConstants.hrApi + 'employee/item',
    save: APIUrlConstants.hrApi + 'employee/save',
  };


  constructor(private http: HttpClient) { }

  getList(filter: FilterModel) {
    return this.http.post<ResponseModel>(this.url.list, filter).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        console.log(xhr);
        return of(null);
      })
    );
  }

  getDropdown() {
    return this.http.get<ResponseModel>(this.url.dropdown).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        console.log(xhr);
        return of(null);
      })
    );
  }

  item(id: number) {
    console.log(id);
    return this.http.get<ResponseModel>(this.url.item + '?id=' + id).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        console.log(xhr);
        return of(null);
      })
    );
  }

  save(model: EmployeeViewModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.url.save, model).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        console.log(xhr);
        return of(null);
      })
    );
  }
}
