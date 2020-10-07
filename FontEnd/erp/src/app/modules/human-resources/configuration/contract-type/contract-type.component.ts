import { Component, OnInit, ViewChild } from '@angular/core';

import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { ContractTypeService } from './contract-type.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ContractTypeFormComponent } from './form/form.component';

@Component({
  selector: 'app-hr-contract-type',
  templateUrl: './contract-type.component.html',
  styleUrls: ['./contract-type.component.scss']
})
export class ContractTypeComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(ContractTypeFormComponent) form: ContractTypeFormComponent;

  permission = new PermissionViewModel();
  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['code', 'name', 'description', 'allowInsurance', 'allowLeaveDate', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(private contractTypeService: ContractTypeService) { }

  ngOnInit(): void {
    this.permission = this.contractTypeService.getPermission();
    this.dataSource.sort = this.sort;
    this.getList();
  }

  reloadTableEventListener($event: boolean) {
    if ($event === true) {
      this.getList();
    }
  }

  onCreateClick() {
    if (this.isLoading === false && this.permission.allowInsert) {
      this.form.onCreateClick();
    }
  }

  onImportClick() {
    if (this.isLoading === false && this.permission.allowInsert) {
      this.form.onCloseClick();
    }
  }

  onExportClick() {
    if (this.isLoading === false && this.permission.allowView) {
      this.form.onCloseClick();
    }
  }

  onUpdateClick(id: number) {
    if (this.isLoading === false && this.permission.allowUpdate && id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number, rowVersion: any) {
    if (this.isLoading === false && this.permission.allowDelete) {
      this.form.onCloseClick();

      this.contractTypeService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
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

    this.contractTypeService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }
}
