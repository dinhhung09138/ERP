import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable, EMPTY } from 'rxjs';

import { DialogDataViewModel } from '../models/dialog-data.model';
import { DialogService } from './../services/dialog.service';
import { HttpErrorStatusEnum } from './../enums/http-error.enum';

@Injectable()
export class NetworkInterceptor implements HttpInterceptor {

  constructor(private dialogService: DialogService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (navigator.onLine === false) {
      const errorModel = {
        isError: true,
        httpError: HttpErrorStatusEnum.noInternet
      } as DialogDataViewModel;

      this.dialogService.openErrorDialog(errorModel);
      return EMPTY;
    }

    return next.handle(req);
  }
}
