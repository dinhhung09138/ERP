import { FilterModel } from 'src/app/core/models/filter-table.model';
import { TrainingCenterViewModel } from './training-center.model';
import { map, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';

@Injectable()
export class TrainingCenterService {
  url = {
    list: APIUrlConstants.hrApi + 'training-center/get-list',
    dropdown: APIUrlConstants.hrApi + 'training-center/dropdown',
    item: APIUrlConstants.hrApi + 'training-center/item',
    save: APIUrlConstants.hrApi + 'training-center/save',
  };

  constructor(private http: HttpClient) {}

  getList(filter: FilterModel) {
    return this.http.post<ResponseModel>(this.url.list, filter).pipe(
      map((data) => {
        return data;
      }),
      catchError((xhr) => {
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
      catchError((xhr) => {
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
      catchError((xhr) => {
        console.log(xhr);
        return of(null);
      })
    );
  }

  save(model: TrainingCenterViewModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.url.save, model).pipe(
      map((data) => {
        return data;
      }),
      catchError((xhr) => {
        console.log(xhr);
        return of(null);
      })
    );
  }
}
