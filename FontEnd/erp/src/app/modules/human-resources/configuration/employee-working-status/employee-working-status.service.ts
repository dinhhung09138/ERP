import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeWorkingStatusViewModel } from './employee-working-status.model';

@Injectable()
export class EmployeeWorkingStatusService {

  url = {
    list: APIUrlConstants.hrApi + 'employee-working-status/get-list',
    dropdown: APIUrlConstants.hrApi + 'employee-working-status/dropdown',
    item: APIUrlConstants.hrApi + 'employee-working-status/item',
    save: APIUrlConstants.hrApi + 'employee-working-status/save',
  };

  constructor(private http: HttpClient) { }

  getList(filter: FilterModel) {
    return this.http.post<ResponseModel>(this.url.list, filter).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
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
        return of(null);
      })
    );
  }

  item(id: number) {
    return this.http.get<ResponseModel>(this.url.item + '?id=' + id).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        return of(null);
      })
    );
  }

  save(model: EmployeeWorkingStatusViewModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.url.save, model).pipe(
      map((data) => {
        return data;
      }),
      catchError(xhr => {
        return of(null);
      })
    );
  }

}
