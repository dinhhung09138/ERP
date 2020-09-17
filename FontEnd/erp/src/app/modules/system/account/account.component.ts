import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';

import { AccountViewModel } from './account.model';
import { AccountService } from './account.service';
import { PagingModel } from '../../../core/models/paging.model';
import { ResponseModel } from '../../../core/models/response.model';
import { ResponseStatus } from '../../../core/enums/response-status.enum';
import { AccountFormComponent } from './form/form.component';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  @ViewChild(AccountFormComponent, {static: true}) form: AccountFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['employeeName', 'userName', 'roleName', 'lastLogin', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  listModuleData: AccountViewModel[];

  constructor(
    private accountService: AccountService,
  ) { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.getList();
  }

  reloadTableEventListener($event: boolean) {
    if ($event === true) {
      this.getList();
    }
  }

  onCreateClick() {
    if (this.isLoading === false) {
      this.form.onCreateClick();
    }
  }

  onUpdateClick(id: number) {
    if (id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number, rowVersion: any) {

  }

  onImportClick() {
    if (this.isLoading === false) {
      this.form.onCloseClick();
    }
  }

  onExportClick() {
    if (this.isLoading === false) {
      this.form.onCloseClick();
    }
  }

  onFilterChange() {
    if (this.isLoading === false) {
      if (this.searchText.length > 0) {
        this.paging.pageIndex = 0;
      }
      this.getList();
    }
  }

  onPageChange(page: PageEvent) {
    if (this.isLoading === false) {
      this.paging.pageSize = page.pageSize;
      this.paging.pageIndex = page.pageIndex;

      if (page.pageSize !== this.currentPageSize) {
        this.currentPageSize = page.pageSize;
        this.paging.pageIndex = 0;
      }
      this.getList();
    }
  }

  private getList() {
    this.isLoading = true;
    this.accountService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }

}
