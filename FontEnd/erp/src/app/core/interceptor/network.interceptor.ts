import { DialogDataInterface } from './../interfaces/dialog-data.interface';
import { DialogService } from './../services/dialog.service';
import { HttpErrorStatusEnum } from './../enums/http-error.enum';
import { Observable, EMPTY } from 'rxjs';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class NetworkInterceptor implements HttpInterceptor {

  constructor(private dialogService: DialogService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (navigator.onLine === false) {
      const errorModel = {
        isError: true,
        httpError: HttpErrorStatusEnum.noInternet
      } as DialogDataInterface;

      this.dialogService.openErrorDialog(errorModel);
      return EMPTY;
    }

    return next.handle(req);
  }
}
