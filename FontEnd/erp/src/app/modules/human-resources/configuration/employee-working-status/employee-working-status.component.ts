import { Component, OnInit, ViewChild } from '@angular/core';

import { PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeWorkingStatusService } from './employee-working-status.service';
import { EmployeeWorkingStatusFormComponent } from './form/form.component';

@Component({
  selector: 'app-employee-working-status',
  templateUrl: './employee-working-status.component.html',
  styleUrls: ['./employee-working-status.component.scss']
})
export class EmployeeWorkingStatusComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(EmployeeWorkingStatusFormComponent) form: EmployeeWorkingStatusFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['code', 'name', 'description', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(private workingStatusService: EmployeeWorkingStatusService) { }

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
    if (this.isLoading !== true) {
      this.form.onCreateClick();
    }
  }

  onImportClick() {
    if (this.isLoading !== true) {
      this.form.onCloseClick();
    }
  }

  onExportClick() {
    if (this.isLoading !== true) {
      this.form.onCloseClick();
    }
  }

  onUpdateClick(id: number) {
    if (this.isLoading !== true && id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number, rowVersion: any) {
    if (this.isLoading !== true) {
      this.form.onCloseClick();

      this.workingStatusService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.getList();
        }
      });
    }
  }

  onFilterChange() {
    if (this.isLoading !== true) {
      if (this.searchText.length > 0) {
        this.paging.pageIndex = 0;
      }
      this.getList();
    }
  }

  onPageChange(page: PageEvent) {
    if (this.isLoading !== true) {
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
    this.workingStatusService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }
}
