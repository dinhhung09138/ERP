import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';
import { EducationService } from './education.service';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { EducationFormComponent } from './form/form.component';
import { MatDialog } from '@angular/material/dialog';
import { FormActionStatus } from 'src/app/core/enums/form-action-status.enum';
import { EducationViewModel } from './education.model';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-hr-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.css']
})
export class EducationComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(EducationFormComponent) form: EducationFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private dialog: MatDialog,
    private educationService: EducationService) { }

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
      width: '300px'
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
    this.educationService.getList(filter).subscribe((response: ResponseModel) => {
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }

  private deleteItem(itemId: number) {
    this.isLoading = true;
    const model = { id: itemId, action: FormActionStatus.Delete } as EducationViewModel;

    this.educationService.save(model).subscribe((response: ResponseModel) => {
      this.isLoading = false;
      if (response) {
        this.getList();
      }
    });
  }

}
