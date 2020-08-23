import { NotifyComponent } from './../../shared/components/notify/notify.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../constants/app.constant';

@Injectable()
export class NotifyService {

  constructor(
    private snackBar: MatSnackBar,
    private translate: TranslateService) {
      translate.use(ApplicationConstant.defaultLanguage);
    }

  openDialogSuccess() {
    this.snackBar.openFromComponent(NotifyComponent, {
      duration: 2500,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: 'snack-bar-dialog-success'
    });
  }

  /**
   * Show notify when user do delete insert new data.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyInsert(isSuccess: boolean) {
    if (isSuccess === true) {
      this.translate.get('MESSAGE.SAVE_SUCCESS').subscribe(mesage => {
        this.notifySuccess(mesage);
      });
    } else {
      this.translate.get('MESSAGE.SAVE_ERROR').subscribe(mesage => {
        this.notifyWarning(mesage);
      });
    }
  }

  /**
   * Show notify when user do delete update.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyUpdate(isSuccess: boolean) {
    if (isSuccess === true) {
      this.translate.get('MESSAGE.EDIT_SUCCESS').subscribe(mesage => {
        this.notifySuccess(mesage);
      });
    } else {
      this.translate.get('MESSAGE.EDIT_ERROR').subscribe(mesage => {
        this.notifyWarning(mesage);
      });
    }
  }

  /**
   * Show notify when user do delete action.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyDelete(isSuccess: boolean) {
    if (isSuccess === true) {
      this.translate.get('MESSAGE.DELETE_SUCCESS').subscribe(mesage => {
        this.notifySuccess(mesage);
      });
    } else {
      this.translate.get('MESSAGE.DELETE_ERROR').subscribe(mesage => {
        this.notifyWarning(mesage);
      });
    }
  }

  /**
   * Show warning when out of date data.
   */
  notifyDataOutOfDate() {
    this.translate.get('MESSAGE.OUT_OF_DATE_DATA').subscribe(message => {
      this.notifyWarning(message);
    });
  }

  /**
   * Show warning when code is exists.
   */
  notifyCodeExists() {
    this.translate.get('MESSAGE.CODE_EXISTS').subscribe(message => {
      this.notifyWarning(message);
    });
  }

  /**
   * Show warning when code is exists.
   */
  notifyCannotGetDropdown(url: string) {
    if (url.includes('/hr/approve-status/dropdown')) {
      this.translate.get('SCREEN.HR.CONFIGURATION.APPROVE_STATUS.ERROR.DROPDOWN').subscribe(message => {
        this.notifyWarning(message);
      });
    } else if (url.includes('/system')) {

    } else if (url.includes('/common')) {

    }
  }

  /**
   * Show warning when server response warning status.
   * @param message : String
   */
  notifyServerWarning(message: string) {
    this.notifyWarning(message);
  }

  /**
   * Show error when server response warning status.
   * @param message : String
   */
  notifyServerError(message: string) {
    this.notifyError(message);
  }

  /**
   * Notify success message.
   * @param message : String
   */
  private notifySuccess(message: string) {
    this.snackBar.open(message, 'X', {
      duration: 2500,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: 'snack-bar-notify-success'
    });
  }

  /**
   * Notify warning message.
   * @param message : String
   */
  private notifyWarning(message: string) {
    this.snackBar.open(message, 'X', {
      duration: 4000,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: 'snack-bar-notify-warning'
    });
  }

  /**
   * Notify error message.
   * @param message : String,
   */
  private notifyError(message: string) {
    this.snackBar.open(message, 'X', {
      duration: 5000,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: 'snack-bar-notify-error'
    });
  }

}
