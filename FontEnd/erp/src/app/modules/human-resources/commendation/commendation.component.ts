import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PagingConstants } from 'src/app/core/constants/paging.constant';
import { CommendationViewModel } from './commendation.model';
import { CommendationService } from './commendation.service';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Component({
  selector: 'app-commendation',
  templateUrl: './commendation.component.html',
  styleUrls: ['./commendation.component.css']
})
export class CommendationComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  searchText = '';
  currentPageSize = PagingConstants.pageSize;

  listColumnsName: string[] = ['name', 'description', 'isActive', 'action'];

  list: CommendationViewModel[] = [];

  dataSource = new MatTableDataSource(this.list);

  constructor(private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.paginator.pageSize = PagingConstants.pageSize;
    this.paginator.pageIndex = 0;
    this.paginator.length = 0;
    this.paginator.pageSizeOptions = PagingConstants.pageSizeOptions;
    this.getList();
  }

  filterTable() {
    if (this.searchText.length > 0) {
      this.paginator.pageIndex = 0;
    }
    this.getList();
  }

  pageChange(page: PageEvent) {
    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paginator.pageIndex = 0;
    }
    this.getList();
  }

  private getList() {
    const filter = new FilterModel();
    filter.text = this.searchText;
    filter.paging.pageIndex = this.paginator.pageIndex;
    filter.paging.pageSize = this.paginator.pageSize;
    this.commendationService.getList(filter).subscribe((response: ResponseModel) => {
      console.log(response);
      if (response.responseStatus === ResponseStatus.success) {
        this.list = response.result.items;
        this.paginator.length = response.result.totalItems;
      }
    });
  }

}
