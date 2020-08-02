import { NotifyService } from './../services/notify.service';
import { DialogDataInterface } from './../interfaces/dialog-data.interface';
import { DialogService } from './../services/dialog.service';
import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { catchError, retry, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseStatus } from '../enums/response-status.enum';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private dialogService: DialogService,
    private notifyService: NotifyService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {

        if (event instanceof HttpResponse) {
          const response = event.body as ResponseModel;

          switch (response.responseStatus) {
            case ResponseStatus.error:
              this.notifyService.notifyServerError(response.errors.join(''));
              break;
            case ResponseStatus.warning:
              this.notifyService.notifyServerWarning(response.errors.join(''));
              break;
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
            const error500 = {
              isError: true,
              httpError: HttpErrorStatusEnum.serverNotFound
            } as DialogDataInterface;
            this.dialogService.openErrorDialog(error500);
            break;
          case 404:
            const error404 = {
              isError: true,
              httpError: HttpErrorStatusEnum.notFound
            } as DialogDataInterface;
            this.dialogService.openErrorDialog(error404);
            break;
          case 204:
            const error204 = {
              isError: true,
              httpError: HttpErrorStatusEnum.noContent
            } as DialogDataInterface;
            this.dialogService.openErrorDialog(error204);
            break;
        }
        console.log(error.error);
        return throwError(error);
      })
    );
  }

}
