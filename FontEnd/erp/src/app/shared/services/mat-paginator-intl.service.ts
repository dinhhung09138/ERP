import { Injectable, OnInit } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../core/constants/app.constant';


@Injectable()
export class AppMatPaginatorIntl extends MatPaginatorIntl{

  constructor(private translate: TranslateService) {
    super();
    translate.use(ApplicationConstant.defaultLanguage);
    this.initMessage();
  }

  itemsPerPageLabel = '';

  firstPageLabel = '';

  lastPageLabel = '';

  nextPageLabel = '';

  previousPageLabel = '';

  initMessage() {
    this.translate.get('TABLE.NAVIGATOR.DISPLAY').subscribe(message => {
      this.itemsPerPageLabel = message;
    });
    this.translate.get('TABLE.NAVIGATOR.FIRST').subscribe(message => {
      this.firstPageLabel = message;
    });
    this.translate.get('TABLE.NAVIGATOR.LAST').subscribe(message => {
      this.lastPageLabel = message;
    });
    this.translate.get('TABLE.NAVIGATOR.NEXT').subscribe(message => {
      this.nextPageLabel = message;
    });
    this.translate.get('TABLE.NAVIGATOR.PREVIOUS').subscribe(message => {
      this.previousPageLabel = message;
    });
  }

  getRangeLabel = (page: number, pageSize: number, length: number) => {
    if (length === 0 || pageSize === 0) {
      return `0 / ${length}`;
    }

    length = Math.max(length, 0);

    const startIndex = page * pageSize;
    const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length)
                                          : startIndex + pageSize;

    return `${startIndex + 1} - ${endIndex} / ${length}`;
  }
}
