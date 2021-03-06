import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { SpecializeViewModel } from './specialize.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class SpecializeService {

  url = {
    list: APIUrlConstants.hrApi + 'specialize/list',
    dropdown: APIUrlConstants.hrApi + 'specialize/dropdown',
    item: APIUrlConstants.hrApi + 'specialize/item',
    save: APIUrlConstants.hrApi + 'specialize/save',
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

  save(model: SpecializeViewModel): Observable<ResponseModel> {
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
