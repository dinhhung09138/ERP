import { ErrorDialogComponent } from './../../shared/components/error-dialog/error-dialog.component';
import { DialogDataInterface } from './../interfaces/dialog-data.interface';
import { ConfirmDialogComponent } from './../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { Injectable } from '@angular/core';
import { HttpErrorStatusEnum } from '../enums/http-error.enum';

@Injectable()
export class DialogService {

  constructor(private dialog: MatDialog) {}

  openConfirmDialog() {
    this.dialog.open(ConfirmDialogComponent, {
    });
  }

  openErrorDialog(errorModel: DialogDataInterface) {

    const disableClosed = errorModel.isError === true && errorModel.httpError === HttpErrorStatusEnum.noInternet;

    this.dialog.open(ErrorDialogComponent, {
      width: '300px',
      disableClose: disableClosed,
      data: errorModel
    });
  }

}
