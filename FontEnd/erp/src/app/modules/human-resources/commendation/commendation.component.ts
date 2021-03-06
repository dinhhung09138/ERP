import { Component, OnInit, ViewChild } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

import { PermissionViewModel } from './../../../core/models/permission.model';
import { CommendationService } from './commendation.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { CommendationFormComponent } from './form/form.component';

@Component({
  selector: 'app-hr-commendation',
  templateUrl: './commendation.component.html',
  styleUrls: ['./commendation.component.scss']
})
export class CommendationComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'description', 'money', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private dialog: MatDialog,
    private commendationService: CommendationService) { }

  ngOnInit(): void {
    this.permission = this.commendationService.getPermission();
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

      this.commendationService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
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
    this.commendationService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }

  private openModalForm(id?: number) {
    if (this.isLoading === false) {
      const modalRef = this.dialog.open(CommendationFormComponent, {
        disableClose: true,
        panelClass: 'mat-modal-md',
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
