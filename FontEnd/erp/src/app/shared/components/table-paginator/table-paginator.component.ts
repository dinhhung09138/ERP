import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { PagingModel } from 'src/app/core/models/paging.model';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-table-paginator',
  templateUrl: './table-paginator.component.html',
  styleUrls: ['./table-paginator.component.scss']
})
export class TablePaginatorComponent implements OnInit {

  @Input() paging: PagingModel;
  @Input() isLoading = false;
  @Output() pageEventChange = new EventEmitter<PageEvent>();

  constructor() {
  }

  ngOnInit(): void {
  }

  onPageChange(event: PageEvent) {
    this.pageEventChange.emit(event);
  }

}
