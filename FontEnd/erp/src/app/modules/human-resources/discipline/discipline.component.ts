import { Component, OnInit, ViewChild } from '@angular/core';
import { PagingModel } from 'src/app/core/models/paging.model';
import { PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DisciplineService } from './discipline.service';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-discipline',
  templateUrl: './discipline.component.html',
  styleUrls: ['./discipline.component.css']
})
export class DisciplineComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  listColumnsName = ['name', 'description', 'isActive', 'action'];
  isLoading = false;
  searchText = '';
  paging = new PagingModel();

  dataSource = new MatTableDataSource();

  constructor(private disciplineService: DisciplineService) { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.getList();
  }

  filterTable() {
    if (this.searchText.length > 0) {
      this.paging.pageIndex = 0;
    }
    this.getList();
  }

  create() {

  }

  update(id: number) {

  }

  pageChange(page: PageEvent) {
    console.log(page);
  }


  getList() {
    this.isLoading = true;
    const filter = new FilterModel();
    filter.paging.pageIndex = this.paging.pageIndex;
    filter.paging.pageSize = this.paging.pageSize;
    filter.text = this.searchText;
    this.disciplineService.getList(filter).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }
}
