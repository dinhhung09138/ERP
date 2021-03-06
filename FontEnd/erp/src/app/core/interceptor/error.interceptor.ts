import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { catchError, retry, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { NotifyService } from './../services/notify.service';
import { DialogDataViewModel } from '../models/dialog-data.model';
import { DialogService } from './../services/dialog.service';
import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from '../enums/response-status.enum';
import { SessionContext } from '../session.context';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    private dialogService: DialogService,
    private notifyService: NotifyService,
    private context: SessionContext) {}

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
            case ResponseStatus.outOfDateData:
              this.notifyService.notifyDataOutOfDate();
              break;
            case ResponseStatus.codeExists:
              this.notifyService.notifyCodeExists();
              break;
            case ResponseStatus.getDropDownError:
              this.notifyService.notifyCannotGetDropdown(req.url);
              break;
            case ResponseStatus.userNameExists:
              this.notifyService.notifyUserNameIsExists();
              break;
          }
        }

        return event;
      })
    )
    .pipe(
      retry(2),
      catchError((error: HttpErrorResponse) => {
        console.log(error.error);

        switch (error.status) {
          case 500:
            const error500 = {
              isError: true,
              httpError: HttpErrorStatusEnum.serverNotFound
            } as DialogDataViewModel;
            this.dialogService.openErrorDialog(error500);
            break;
          case 404:
            const error404 = {
              isError: true,
              httpError: HttpErrorStatusEnum.notFound
            } as DialogDataViewModel;
            this.dialogService.openErrorDialog(error404);
            break;
          case 403:
            const error403 = {
              isError: true,
              httpError: HttpErrorStatusEnum.forbidden,
            } as DialogDataViewModel;
            this.dialogService.openErrorDialog(error403);
            break;
          case 401:
            const error401 = {
              isError: true,
              httpError: HttpErrorStatusEnum.timeOut
            } as DialogDataViewModel;
            this.dialogService.openErrorDialog(error401);
            this.context.clearToken();
            break;
            case 204:
              const error204 = {
                isError: true,
                httpError: HttpErrorStatusEnum.noContent
              } as DialogDataViewModel;
              this.dialogService.openErrorDialog(error204);
              break;
            default:
              const errorNotResponse = {
                isError: true,
                httpError: HttpErrorStatusEnum.serverNotFound
              } as DialogDataViewModel;
              this.dialogService.openErrorDialog(errorNotResponse);
              break;
        }
        return throwError(error);
      })
    );
  }

}
