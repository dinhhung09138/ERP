import { map, catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { ErrorDialogComponent } from './../../shared/components/error-dialog/error-dialog.component';
import { DialogDataInterface } from './../interfaces/dialog-data.interface';
import { ConfirmDialogComponent } from './../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Injectable } from '@angular/core';
import { HttpErrorStatusEnum } from '../enums/http-error.enum';

@Injectable()
export class DialogService {

  constructor(private dialog: MatDialog) {}

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

  openErrorDialog(errorModel: DialogDataInterface) {

    const disableClosed = errorModel.isError === true
                          && (errorModel.httpError === HttpErrorStatusEnum.noInternet
                            || errorModel.httpError === HttpErrorStatusEnum.timeOut
                            || errorModel.httpError === HttpErrorStatusEnum.unauthorized);

    this.dialog.open(ErrorDialogComponent, {
      width: '300px',
      disableClose: disableClosed,
      data: errorModel
    });
  }

}
