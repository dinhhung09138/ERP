import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { SessionContext } from 'src/app/core/session.context';
import { LoginModel } from './../../modules/login/login.model';
import { ResponseModel } from './../models/response.model';
import { APIUrlConstants } from './../constants/api-url.constant';
import { ResponseStatus } from '../enums/response-status.enum';

@Injectable()
export class AuthenticationService {

  url = {
    login: APIUrlConstants.authenticationApi + 'login',
    refreshToken: APIUrlConstants.authenticationApi + 'refresh-token',
    revokeToken: APIUrlConstants.authenticationApi + 'revoke-token',
  };

  constructor(
    private http: HttpClient,
    private context: SessionContext) { }

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

  refreshToken(delayTime: number = 0) {
    setTimeout(() => {
      if (this.context.isAuthenticated() === true) {
        const refreshTokenModel = this.context.getRefreshToken();
        if (refreshTokenModel) {
          this.http.post<ResponseModel>(this.url.refreshToken, refreshTokenModel).toPromise().then(
            (response: ResponseModel) => {
              if (response && response.responseStatus === ResponseStatus.success) {
                this.context.saveToken(response.result);
              } else {
                this.context.clearToken();
              }
            }
          );
        }
      }
    }, delayTime);
  }

  revokeToken() {
    if (this.context.isAuthenticated() === true) {
      const refreshTokenModel = this.context.getRefreshToken();

      if (refreshTokenModel) {
        this.http.post<ResponseModel>(this.url.revokeToken, refreshTokenModel).toPromise();
      }
    }
  }
}
