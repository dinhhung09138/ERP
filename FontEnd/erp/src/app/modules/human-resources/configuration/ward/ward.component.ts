import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';
import { WardService } from './ward.service';
import { FilterModel } from 'src/app/core/models/filter-table.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { WardFormComponent } from './form/form.component';
import { ActivatedRoute } from '@angular/router';
import { ProvinceViewModel } from '../province/province.model';
import { DistrictViewModel } from '../district/district.model';
import { FormActionStatus } from '../../../../core/enums/form-action-status.enum';
import { WardViewModel } from './ward.model';
import { ConfirmDialogComponent } from '../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-hr-ward',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.css']
})
export class WardComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(WardFormComponent) form: WardFormComponent;

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'districtName', 'provinceName', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  provinceList: ProvinceViewModel[] = [];
  districtList: DistrictViewModel[] = [];

  constructor(
    public dialog: MatDialog,
    private wardService: WardService,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(res => {
      this.provinceList = res.data.provinces.result;
      this.districtList = res.data.districts.result;
    });
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
    if (this.isLoading === true) {
      return;
    }
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
    this.wardService.getList(filter).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }

  private deleteItem(itemId: number) {
    this.isLoading = true;
    const model = { action: FormActionStatus.Delete, id: itemId } as WardViewModel;
    this.wardService.save(model).subscribe((response: ResponseModel) => {
      this.isLoading = false;
      if (response !== null && response.responseStatus === ResponseStatus.success) {
        this.getList();
      }
    });
  }

}
