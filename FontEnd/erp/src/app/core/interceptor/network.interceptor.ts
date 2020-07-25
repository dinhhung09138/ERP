import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { ErrorDialogComponent } from './../../shared/components/error-dialog/error-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Observable, EMPTY } from 'rxjs';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class NetworkInterceptor implements HttpInterceptor {

  constructor(private dialog: MatDialog) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (navigator.onLine === false) {
      console.log('No internet connection');
      this.dialog.open(ErrorDialogComponent, {
        width: '300px',

        data: { isError: true, httpError: HttpErrorStatusEnum.noInternet },
      });
      return EMPTY;
    }

    return next.handle(req);
  }
}
