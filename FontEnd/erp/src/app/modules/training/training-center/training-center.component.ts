import { TrainingCenterFormComponent } from './form/form.component';
import { TrainingCenterService } from './training-center.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { PageEvent } from '@angular/material/paginator';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { TrainingCenterViewModel } from './training-center.model';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-training-training-center',
  templateUrl: './training-center.component.html',
  styleUrls: ['./training-center.component.scss']
})
export class TrainingCenterComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(TrainingCenterFormComponent) form: TrainingCenterFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'description', 'avatar', 'phone', 'taxCode', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private dialog: MatDialog,
    private trainingCenterService: TrainingCenterService) { }

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

  onUpdateClick(id: number) {
    if (id !== null) {
      this.form.onUpdateClick(id);
    }
  }

  onDeleteClick(id: number) {
    this.form.onCloseClick();
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result === true) {
        this.deleteItem(id);
      }
    });
  }

  onImportClick() {
    this.form.onCloseClick();
  }

  onExportClick() {
    this.form.onCloseClick();
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
    this.trainingCenterService.getList(filter).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }

  private deleteItem(itemId: number) {
    this.isLoading = true;
    const model = { id: itemId, action: FormActionStatus.Delete } as TrainingCenterViewModel;

    this.trainingCenterService.save(model).subscribe((response: ResponseModel) => {
      this.isLoading = false;
      if (response) {
        this.getList();
      }
    });
  }

}
