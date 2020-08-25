import { ReligionFormComponent } from './form/form.component';
import { MatSort } from '@angular/material/sort';
import { PagingModel } from 'src/app/core/models/paging.model';
import { MatTableDataSource } from '@angular/material/table';
import { ReligionService } from './religion.service';
import { PageEvent } from '@angular/material/paginator';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { ResponseModel } from 'src/app/core/models/response.model';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-hr-religion',
  templateUrl: './religion.component.html',
  styleUrls: ['./religion.component.css']
})
export class ReligionComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(ReligionFormComponent) form: ReligionFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  constructor(
    private religionService: ReligionService
    ) {
  }

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

      this.religionService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
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
    this.religionService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }
}
