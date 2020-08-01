import { NotifyComponent } from './../../shared/components/notify/notify.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Injectable } from '@angular/core';

@Injectable()
export class NotifyService {

  constructor(private snackBar: MatSnackBar) {}

  openDialogSuccess() {
    this.snackBar.openFromComponent(NotifyComponent, {
      duration: 2500,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: 'snack-bar-dialog-success'
    });
  }

  /**
   * Show notify when user do delete create.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyCreate(isSuccess: boolean) {
    if (isSuccess === true) {
      this.notifySuccess('Thêm mới dữ liệu thành công');
    } else {
      this.notifyWarning('Thêm mới dữ liệu thất bại');
    }
  }

  /**
   * Show notify when user do delete update.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyUpdate(isSuccess: boolean) {
    if (isSuccess === true) {
      this.notifySuccess('Cập nhật dữ liệu thành công');
    } else {
      this.notifyWarning('Cập nhật dữ liệu thất bại');
    }
  }

  /**
   * Show notify when user do delete action.
   * @param isSuccess : true: Success, false: Fail
   */
  notifyDelete(isSuccess: boolean) {
    if (isSuccess === true) {
      this.notifySuccess('Đữ liệu bạn chọn đã được xóa');
    } else {
      this.notifyWarning('Lỗi khi xóa dữ liệu');
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
      verticalPosition: 'top',
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
      verticalPosition: 'top',
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
      verticalPosition: 'top',
      panelClass: 'snack-bar-notify-error'
    });
  }

}
