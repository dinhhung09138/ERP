import { DialogDataInterface } from './../../../core/interfaces/dialog-data.interface';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpErrorStatusEnum } from 'src/app/core/enums/http-error.enum';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.css']
})
export class ErrorDialogComponent implements OnInit {

  errorMessage = '';

  constructor(
    private translate: TranslateService,
    @Inject(MAT_DIALOG_DATA) public data: DialogDataInterface
  ) {
   }

  ngOnInit(): void {
    this.errorMessage = '';
    if (this.data.isError === true) {

      let key = '';

      switch (this.data.httpError) {
        case HttpErrorStatusEnum.warningError:
          this.errorMessage = this.data.message;
          break;
        case HttpErrorStatusEnum.timeOut:
          key = 'MESSAGE.TOKEN_TIMEOUT';
          break;
        case HttpErrorStatusEnum.noInternet:
          key = 'MESSAGE.INTERNET_CONNECTION';
          break;
        case HttpErrorStatusEnum.serverNotFound:
          key = 'MESSAGE.SERVER_NOTFOUND';
          break;
        case HttpErrorStatusEnum.unauthorized:
          key = 'MESSAGE.UNAUTHORIZE';
          break;
        case HttpErrorStatusEnum.notFound:
          key = 'MESSAGE.URL_NOTFOUND';
          break;
        case HttpErrorStatusEnum.noContent:
          key = 'MESSAGE.CONTENT_NOTFOUND';
          break;
      }

      this.translate.get(key).subscribe(msg => {
        this.errorMessage = msg;
      });
    }
  }

}
