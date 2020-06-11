import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { of, Observable } from 'rxjs';

@Injectable()
export class DisciplineService {

  url = {
    list: APIUrlConstants.hrApi + 'discipline/getlist',
    item: APIUrlConstants.hrApi + 'discipline/item',
    save: APIUrlConstants.hrApi + 'discipline/save',
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

}
