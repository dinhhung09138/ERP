import { Component, Input, OnInit, ViewChild } from '@angular/core';


import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

import { EmployeeViewModel } from '../../employee.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { PagingModel } from '../../../../../core/models/paging.model';
import { EmployeeCertificateService } from './certificate.service';
import { EmployeeCertificateFormComponent } from './form/form.component';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { CertificatedViewModel } from './../../../configuration/certificated/certificated.model';
import { SchoolService } from './../../../configuration/school/school.service';
import { CertificatedService } from './../../../configuration/certificated/certificated.service';
import { SchoolViewModel } from './../../../configuration/school/school.model';

@Component({
  selector: 'app-hr-employee-certificate',
  templateUrl: './certificate.component.html',
  styleUrls: ['./certificate.component.scss']
})
export class EmployeeCertificateComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'certificateName',
                                'schoolName',
                                'year',
                              'action' ];
  dataSource = new MatTableDataSource();
  listCertificated: CertificatedViewModel[];
  listSchool: SchoolViewModel[];

  constructor(
    private dialog: MatDialog,
    private employeeCertificateService: EmployeeCertificateService,
    private schoolService: SchoolService,
    private certificatedService: CertificatedService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeCertificateService.getPermission();
    this.dataSource.sort = this.sort;
  }

  onAddClick() {
    if (this.permission.allowInsert === false) {
      return;
    }
    this.showFormModal();
  }

  onUpdateClick(id: number) {
    if (this.permission.allowUpdate === false) {
      return;
    }
    this.showFormModal(id);
  }

  onDeleteClick(id: number, version: any) {
    this.employeeCertificateService.confirmDelete(id, version).subscribe((response: ResponseModel) => {
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
    this.employeeCertificateService.getList(this.paging, this.searchText, this.employee.id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.TotalItems;
      }
      this.isLoading = false;
    });
  }

  public getSchool() {
    this.isLoading = true;
    this.schoolService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listSchool = response.result;
      }
      this.isLoading = false;
    });
  }

  public getCertificated() {
    this.isLoading = true;
    this.certificatedService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listCertificated = response.result;
      }
      this.isLoading = false;
    });
  }

  private showFormModal(id?: number) {
    const modalRef = this.dialog.open(EmployeeCertificateFormComponent, {
      disableClose: true,
      panelClass: 'mat-modal-md',
      data: {
        isPopup: true,
        itemId: id,
        employeeId: this.employee.id,
        listCertificated: this.listCertificated,
        listSchool: this.listSchool,
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
