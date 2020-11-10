import { Injectable } from '@angular/core';

import { map, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

import { ErrorDialogComponent } from './../../shared/components/error-dialog/error-dialog.component';
import { DialogDataViewModel } from '../models/dialog-data.model';
import { ConfirmDialogComponent } from './../../shared/components/confirm-dialog/confirm-dialog.component';
import { HttpErrorStatusEnum } from '../enums/http-error.enum';

@Injectable()
export class DialogService {

  constructor(
    private dialog: MatDialog,
  ) {}

  openConfirmDeleteDialog(): Observable<boolean> {
    const modalRef = this.dialog.open(ConfirmDialogComponent, {
      disableClose: true,
    });

    return modalRef.afterClosed().pipe(
      map((result: boolean) => {
        return result;
      }),
      catchError(xhr => {
        return of(false);
      })
    );
  }

  openErrorDialog(errorModel: DialogDataViewModel) {

    const disableClosed = errorModel.isError === true
                          && (errorModel.httpError === HttpErrorStatusEnum.noInternet
                            || errorModel.httpError === HttpErrorStatusEnum.timeOut
                            || errorModel.httpError === HttpErrorStatusEnum.forbidden
                            || errorModel.httpError === HttpErrorStatusEnum.unauthorized);

    this.dialog.open(ErrorDialogComponent, {
      panelClass: 'mat-modal-sm',
      disableClose: disableClosed,
      data: errorModel
    });
  }

  openUnauthorizeDialog() {
    this.dialog.open(ErrorDialogComponent, {
      panelClass: 'mat-modal-sm',
      disableClose: false,
      data: {
        isError: true,
        httpError: HttpErrorStatusEnum.unauthorized
      }
    });
  }

}
