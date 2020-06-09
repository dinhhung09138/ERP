import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { CommendationViewModel } from './commendation.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';
import { FilterModel } from 'src/app/core/models/filter-table.model';

@Injectable()
export class CommendationService {

  url = {
    list: APIUrlConstants.hrApi + 'commendation/getlist',
    save: APIUrlConstants.hrApi + 'commendation/save',
  };


  constructor(private http: HttpClient) { }

  getList(filter: FilterModel) {
    console.log(filter);
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

  save(model: CommendationViewModel): Observable<ResponseModel> {
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
