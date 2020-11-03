import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { MatSort } from '@angular/material/sort';
import { PagingModel } from 'src/app/core/models/paging.model';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeService } from '../employee.service';
import { PermissionViewModel } from '../../../../core/models/permission.model';

@Component({
  selector: 'app-hr-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName = [
    'employeeCode',
    'fullName',
    'workingEmail',
    'workingPhone',
    'employeeWorkingStatusName',
    'startWorkingDate',
    'isActive',
    'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private employeeService: EmployeeService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeService.getPermission();
    this.dataSource.sort = this.sort;
    this.getList();
  }

  onCreateClick() {
    if (this.isLoading === false && this.permission.allowInsert === true) {
      this.router.navigate(['/hr/employee/new']);
    }
  }

  onImportClick() {
    if (this.isLoading === false && this.permission.allowInsert === true) {
    }
  }

  onExportClick() {
    if (this.isLoading === false && this.permission.allowView === true) {
    }
  }

  onUpdateClick(id: number) {
    if (this.isLoading === false && id !== null && this.permission.allowUpdate === true) {
      this.router.navigate([`/hr/employee/edit/${id}`]);
    }
  }

  onDeleteClick(id: number) {
    if (this.isLoading === false) {
      this.employeeService.confirmDelete(id).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.getList();
        }
      });
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
    this.employeeService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }
}
