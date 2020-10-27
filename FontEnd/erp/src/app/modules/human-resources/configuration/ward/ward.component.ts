import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PageEvent } from '@angular/material/paginator';

import { PermissionViewModel } from './../../../../core/models/permission.model';
import { WardService } from './ward.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';
import { PagingModel } from 'src/app/core/models/paging.model';
import { WardFormComponent } from './form/form.component';
import { ProvinceViewModel } from '../province/province.model';
import { DistrictViewModel } from '../district/district.model';

@Component({
  selector: 'app-hr-ward',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.scss']
})
export class WardComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'districtName', 'provinceName', 'precedence', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  listProvince: ProvinceViewModel[] = [];
  listDistrict: DistrictViewModel[] = [];

  constructor(
    private dialog: MatDialog,
    private wardService: WardService,
    private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.permission = this.wardService.getPermission();
    this.activatedRoute.data.subscribe(res => {
      this.listProvince = res.data.provinces.result;
      this.listDistrict = res.data.districts.result;
    });
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

      this.wardService.confirmDelete(id, rowVersion).subscribe((response: ResponseModel) => {
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
    this.wardService.getList(this.paging, this.searchText).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
      }
      this.isLoading = false;
    });
  }

  private openModalForm(id?: number) {
    if (this.isLoading === false) {
      const modalRef = this.dialog.open(WardFormComponent, {
        disableClose: true,
        panelClass: 'mat-modal-sm',
        data: {
          isPopup: true,
          itemId: id,
          listDistrict: this.listDistrict,
          listProvince: this.listProvince
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
