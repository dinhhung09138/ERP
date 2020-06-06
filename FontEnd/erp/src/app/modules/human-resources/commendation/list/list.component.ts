import { Component, OnInit, ViewChild } from '@angular/core';
import { CommendationViewModal } from '../commendation.model';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PagingConstants } from 'src/app/core/constants/paging.constant';

@Component({
  selector: 'app-commendation-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class CommendationListComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  searchText = '';
  currentPageSize = PagingConstants.pageSize;

  listColumnsName: string[] = ['name', 'description', 'isActive', 'action'];

  list: CommendationViewModal[] = [
    {
      id: 1,
      name: 'Cu ty',
      description: 'Toi la Cu ty',
      money: 0,
      isActive: false,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Long',
      description: 'Toi La Long',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Nam',
      description: 'Toi La Nam',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }, {
      id: 1,
      name: 'Hung',
      description: 'Tran Dinh Hung',
      money: 0,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }
  ];

  dataSource = new MatTableDataSource(this.list);

  constructor() { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.paginator.pageSize = PagingConstants.pageSize;
    this.paginator.pageIndex = 0;
    this.paginator.length = 100;
    this.paginator.pageSizeOptions = PagingConstants.pageSizeOptions;
  }

  filterTable() {
    if (this.searchText.length > 0) {
      this.dataSource.filter = this.searchText.trim().toLowerCase();
      this.paginator.pageIndex = 0;
    }
  }

  pageChange(page: PageEvent) {
    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paginator.pageIndex = 0;
    }
  }

}
