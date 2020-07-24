import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { PagingModel } from 'src/app/core/models/paging.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { EmployeeWorkingStatusViewModel } from './employee-working-status.model';
import { EmployeeWorkingStatusService } from './employee-working-status.service';
import { EmployeeWorkingStatusFormComponent } from './form/form.component';

@Component({
  selector: 'app-employee-working-status',
  templateUrl: './employee-working-status.component.html',
  styleUrls: ['./employee-working-status.component.css']
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

  constructor(
    private dialog: MatDialog,
    private workingStatusService: EmployeeWorkingStatusService
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
    this.form.onCreateClick();
  }

  onImportClick() {
    this.form.onCloseClick();
  }

  onExportClick() {
    this.form.onCloseClick();
  }

  onUpdateClick(id: number) {
    if (id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number) {
    this.form.onCloseClick();
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
    });

    dialogRef.beforeClosed().subscribe(result => {
      if (result === true) {
        this.deleteItem(id);
      }
    });
  }

  onFilterChange() {
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

    this.workingStatusService.getList(filter).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }

  private deleteItem(itemId: number) {
    this.isLoading = true;
    const model = { id: itemId, action: FormActionStatus.Delete } as EmployeeWorkingStatusViewModel;

    this.workingStatusService.save(model).subscribe((response: ResponseModel) => {
      this.isLoading = false;
      if (response) {
        this.getList();
      }
    });
  }

}
