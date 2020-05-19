import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { LoginModel } from './login.model';
import { Observable, of } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ApiUrlModel } from 'src/app/core/models/api-url.model';

@Injectable()
export class LoginService {

  url = {
    login: ApiUrlModel.authenticationApi + 'login'
  };

  constructor(private http: HttpClient) {}

  login(model: LoginModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(this.url.login, model).pipe(
      map((data) => {
        return data;
      }),
      catchError(err => {
        console.log(err);
        return of(null);
      })
    );
  }
}

