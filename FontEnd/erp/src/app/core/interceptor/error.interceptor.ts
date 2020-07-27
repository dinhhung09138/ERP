import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { ErrorDialogComponent } from './../../shared/components/error-dialog/error-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, retry, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseStatus } from '../enums/response-status.enum';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private dialog: MatDialog) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {

        if (event instanceof HttpResponse) {
          const response = event.body as ResponseModel;
          if (response.responseStatus === ResponseStatus.error) {
            this.dialog.open(ErrorDialogComponent, {
              width: '300px',
              data: { isError: true, httpError: HttpErrorStatusEnum.serverNotFound }
            });
          }
        }

        return event;
      })
    )
    .pipe(
      retry(2),
      catchError((error: HttpErrorResponse) => {

        switch(error.status) {
          case 500:
            this.dialog.open(ErrorDialogComponent, {
              width: '300px',
              data: { isError: true, httpError: HttpErrorStatusEnum.serverNotFound }
            });
            break;
          case 404:
            this.dialog.open(ErrorDialogComponent, {
              width: '300px',
              data: { isError: true, httpError: HttpErrorStatusEnum.notFound }
            });
            break;
          case 204:
            this.dialog.open(ErrorDialogComponent, {
              width: '300px',
              data: { isError: true, httpError: HttpErrorStatusEnum.noContent }
            });
            break;
        }
        console.log(error.error);
        return throwError(error);
      })
    );
  }

}
