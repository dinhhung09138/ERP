import { DialogDataInterface } from './../../../core/interfaces/dialog-data.interface';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpErrorStatusEnum } from 'src/app/core/enums/http-error.enum';

@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.css']
})
export class ErrorDialogComponent implements OnInit {

  errorMessage = '';

  constructor(
    private dialogRef: MatDialogRef<ErrorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogDataInterface
  ) { }

  ngOnInit(): void {
    this.errorMessage = '';
    if (this.data.isError === true) {
      switch(this.data.httpError) {
        case HttpErrorStatusEnum.noInternet:
          this.errorMessage = 'Vui lòng kiểm tra đường truyền internet';
          break;
        case HttpErrorStatusEnum.serverNotFound:
          this.errorMessage = 'Không thể kết nối tới server';
          break;
        case HttpErrorStatusEnum.unauthorized:
          this.errorMessage = 'Bạn không có quyền thao tác trên tính năng này';
          break;
        case HttpErrorStatusEnum.notFound:
          this.errorMessage = 'Liên kết không tồn tại trên server';
          break;
        case HttpErrorStatusEnum.noContent:
          this.errorMessage = 'Không tìm thấy nội dung';
          break;
      }
    }
  }

}
