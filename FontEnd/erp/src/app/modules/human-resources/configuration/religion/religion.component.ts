import { Component, OnInit, ViewChild } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { ReligionFormComponent } from './form/form.component';
import { ReligionService } from './religion.service';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';

@Component({
  selector: 'app-hr-religion',
  templateUrl: './religion.component.html',
  styleUrls: ['./religion.component.scss']
})
export class ReligionComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private dialog: MatDialog,
    private religionService: ReligionService
    ) {
  }

  ngOnInit(): void {
    this.permission = this.religionService.getPermission();
    this.dataSource.sort = this.sort;
    this.getList();
  }

  onCreateClick() {
    this.openModalForm();
  }

  onImportClick() {
    if (this.isLoading === false) {
    }
  }

  onExportClick() {
    if (this.isLoading === false) {
    }
  }

  onUpdateClick(id: number) {
    this.openModalForm(id);
  }

  onDeleteClick(id: number, rowVersion: any) {
    if (this.isLoading === false) {

      this.religionService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
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
    this.religionService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }

  private openModalForm(id?: number) {
    if (this.isLoading === false) {
      const modalRef = this.dialog.open(ReligionFormComponent, {
        disableClose: true,
        panelClass: 'mat-modal-sm',
        data: {
          isPopup: true,
          itemId: id,
        }
      });

      modalRef.afterClosed().subscribe(
        (result: boolean) => {
          if (result === true) {
            this.getList();
          }
        }
      );
    }
  }
}
