import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { ProvinceViewModel } from './province.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class ProvinceService {

  url = {
    list: APIUrlConstants.hrApi + 'province/get-list',
    item: APIUrlConstants.hrApi + 'province/item',
    save: APIUrlConstants.hrApi + 'province/save',
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

  save(model: ProvinceViewModel): Observable<ResponseModel> {
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
