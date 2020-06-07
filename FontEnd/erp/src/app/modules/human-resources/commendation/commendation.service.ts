import { Injectable } from "@angular/core";
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';
import { HttpClient } from '@angular/common/http';
import { CommendationViewModal } from './commendation.model';
import { Observable, of } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class CommendationService {

  url = {
    list: APIUrlConstants.hrApi + 'list',
    save: APIUrlConstants.hrApi + 'save',
  };


  constructor(private http: HttpClient) { }

  save(model: CommendationViewModal): Observable<ResponseModel> {
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
