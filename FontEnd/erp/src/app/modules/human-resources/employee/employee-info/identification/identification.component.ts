import { Component, Input, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

import { EmployeeViewModel } from '../../employee.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { PagingModel } from '../../../../../core/models/paging.model';
import { IdentificationTypeViewModel } from '../../../configuration/identification-type/identification-type.model';
import { EmployeeIdentificationService } from './identification.service';
import { IdentificationTypeService } from '../../../configuration/identification-type/identification-type.service';
import { EmployeeIdentificationFormComponent } from './form/form.component';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { ProvinceService } from '../../../configuration/province/province.service';
import { ProvinceViewModel } from '../../../configuration/province/province.model';

@Component({
  selector: 'app-hr-employee-identification',
  templateUrl: './identification.component.html',
  styleUrls: ['./identification.component.scss']
})
export class EmployeeIdentificationComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'identificationTypeName', 'code', 'expirationDate', 'placeName', 'notes', 'action' ];
  dataSource = new MatTableDataSource();
  listIdentificationType: IdentificationTypeViewModel[];
  listProvince: ProvinceViewModel[];

  constructor(
    private dialog: MatDialog,
    private employeeIdentificationService: EmployeeIdentificationService,
    private identificationTypeService: IdentificationTypeService,
    private provinceService: ProvinceService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeIdentificationService.getPermission();
    this.dataSource.sort = this.sort;
  }

  onAddClick() {
    this.showFormModal();
  }

  onUpdateClick(id: number) {
    this.showFormModal(id);
  }

  onDeleteClick(id: number, version: any) {
    this.employeeIdentificationService.confirmDelete(id, version).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.getList();
      }
    });
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

  public getList() {
    if (this.employee === undefined) {
      return;
    }
    this.isLoading = true;
    this.employeeIdentificationService.getList(this.paging, this.searchText, this.employee.id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.TotalItems;
      }
      this.isLoading = false;
    });
  }

  public getIdentificationType() {
    this.isLoading = true;
    this.identificationTypeService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listIdentificationType = response.result;
      }
      this.isLoading = false;
    });
  }

  public getProvince() {
    this.isLoading = true;
    this.provinceService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listProvince = response.result;
      }
      this.isLoading = false;
    });
  }

  private showFormModal(id?: number) {
    const modalRef = this.dialog.open(EmployeeIdentificationFormComponent, {
      disableClose: true,
      width: '450px',
      data: {
        isPopup: true,
        listProvince: this.listProvince,
        listIdentificationType: this.listIdentificationType,
        employeeId: this.employee.id,
        itemId: id
      }
    });

    return modalRef.afterClosed().subscribe(
      (result: boolean) => {
        if (result === true) {
          this.getList();
        }
      }
    );

  }

}
