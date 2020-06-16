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

  create() {
    this.form.create();
  }

  update(id: number) {
    if (id !== null) {
      this.form.update(id);
    }
  }

  delete(id: number) {

  }

  filterTable() {
    if (this.searchText.length > 0) {
      this.paging.pageIndex = 0;
    }
    this.getList();
  }

  pageChange(page: PageEvent) {
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
      if (response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.totalItems;
        this.isLoading = false;
      }
    });
  }

}
