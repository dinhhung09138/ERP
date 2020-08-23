import { DialogDataInterface } from './../../../core/interfaces/dialog-data.interface';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';



@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {

  constructor(
    public translate: TranslateService,
    public dialogRef: MatDialogRef<ConfirmDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogDataInterface
  ) {
    translate.use(ApplicationConstant.defaultLanguage);
  }

  ngOnInit(): void {
  }

  onYesClick(): void {
    this.dialogRef.close(true);
  }

  onNoClick(): void {
    this.dialogRef.close(false);
  }

}
