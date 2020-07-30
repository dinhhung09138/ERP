import { Injectable } from '@angular/core';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { EducationViewModel } from './education.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class EducationService {

  url = {
    list: APIUrlConstants.hrApi + 'education/get-list',
    dropdown: APIUrlConstants.hrApi + 'education/dropdown',
    item: APIUrlConstants.hrApi + 'education/item',
    save: APIUrlConstants.hrApi + 'education/save',
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

  save(model: EducationViewModel): Observable<ResponseModel> {
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
