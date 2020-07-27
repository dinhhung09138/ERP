import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';
import { ApproveStatusService } from './approve-status.service';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ApproveStatusFormComponent } from './form/form.component';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ApproveStatusViewModel } from './approve-status.model';

@Component({
  selector: 'app-hr-approve-status',
  templateUrl: './approve-status.component.html',
  styleUrls: ['./approve-status.component.css']
})
export class ApproveStatusComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(ApproveStatusFormComponent) form: ApproveStatusFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['code', 'name', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    public dialog: MatDialog,
    private approveStatusService: ApproveStatusService
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
    if (this.isLoading === true) {
      return;
    }
    this.form.onCreateClick();
  }

  onImportClick() {
    if (this.isLoading === true) {
      return;
    }
    this.form.onCloseClick();
  }

  onExportClick() {
    if (this.isLoading === true) {
      return;
    }
    this.form.onCloseClick();
  }

  onUpdateClick(id: number) {
    if (this.isLoading === true) {
      return;
    }
    if (id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number) {
    if (this.isLoading === true) {
      return;
    }
    this.form.onCloseClick();
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: { title: '', animation: '' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.deleteItem(id);
      }
    });
  }

  onFilterChange() {
    if (this.isLoading === true) {
      return;
    }
    if (this.searchText.length > 0) {
      this.paging.pageIndex = 0;
    }
    this.getList();
  }

  onPageChange(page: PageEvent) {
    this.paging.pageSize = page.pageSize;
    this.paging.pageIndex = page.pageIndex;
    if (page.pageSize !== this.currentPageSize) {
      this.currentPageSize = page.pageSize;
      this.paging.pageIndex = 0;
    }
    this.getList();
  }

  private getList() {
    this.isLoading = true;
    const filter = new FilterModel();
    filter.text = this.searchText;
    filter.paging.pageIndex = this.paging.pageIndex;
    filter.paging.pageSize = this.paging.pageSize;
    this.approveStatusService.getList(filter).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }

  private deleteItem(itemId: number) {
    this.isLoading = true;
    const model = { action: FormActionStatus.Delete, id: itemId } as ApproveStatusViewModel;
    this.approveStatusService.save(model).subscribe((response: ResponseModel) => {
      this.isLoading = false;
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.getList();
      }
    });
  }

}
