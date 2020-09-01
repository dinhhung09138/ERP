import { Component, OnInit, Output, EventEmitter, ElementRef, ViewChild } from '@angular/core';
import { RoleService } from '../role/role.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { MatSort } from '@angular/material/sort';
import { RoleFormComponent } from './form/form.component';
import { PagingModel } from 'src/app/core/models/paging.model';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(RoleFormComponent) form: RoleFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'description', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private roleService: RoleService) { }

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

  onUpdateClick(id: number) {
    if (id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number, rowVersion: any) {
    if (this.isLoading !== true) {
      this.form.onCloseClick();
      this.roleService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
        if (response && response.responseStatus === ResponseStatus.success) {
          this.getList();
        }
      });
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

  getList() {
    this.isLoading = true;
    this.roleService.getList(this.paging,this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }
}
