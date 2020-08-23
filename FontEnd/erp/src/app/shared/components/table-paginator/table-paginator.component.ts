import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PagingModel } from 'src/app/core/models/paging.model';
import { PageEvent } from '@angular/material/paginator';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';

@Component({
  selector: 'app-table-paginator',
  templateUrl: './table-paginator.component.html',
  styleUrls: ['./table-paginator.component.css']
})
export class TablePaginatorComponent implements OnInit {

  @Input() Paging: PagingModel;
  @Input() IsLoading = false;
  @Output() pageEventChange = new EventEmitter<PageEvent>();

  constructor(public translate: TranslateService) {
    translate.use(ApplicationConstant.defaultLanguage);
  }

  ngOnInit(): void {
  }

  onPageChange(event: PageEvent) {
    this.pageEventChange.emit(event);
  }

}
