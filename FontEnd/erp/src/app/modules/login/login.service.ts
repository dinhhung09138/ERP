import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { LoginModel } from './login.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { APIUrlConstants } from 'src/app/core/constants/api-url.constant';

@Injectable()
export class LoginService {

  url = {
    login: APIUrlConstants.authenticationApi + 'login'
  };

  constructor(private http: HttpClient) { }

  login(model: LoginModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.url.login, model).pipe(
      map((data) => {
        return data;
      }),
      catchError(err => {
        return of(null);
      })
    );
  }
}

