import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { RelationshipTypeViewModel } from './relationship-type.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class RelationshipTypeService {

  url = {
    list: APIUrlConstants.hrApi + 'relationship-type/get-list',
    item: APIUrlConstants.hrApi + 'relationship-type/item',
    save: APIUrlConstants.hrApi + 'relationship-type/save',
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

  save(model: RelationshipTypeViewModel): Observable<ResponseModel> {
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
