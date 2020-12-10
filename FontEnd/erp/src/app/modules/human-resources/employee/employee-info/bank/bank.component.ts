import { Component, Input, OnInit, ViewChild } from '@angular/core';


import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

import { EmployeeViewModel } from '../../employee.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { PagingModel } from '../../../../../core/models/paging.model';
import { EmployeeBankService } from './bank.service';
import { EmployeeBankFormComponent } from './form/form.component';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { BankViewModel } from './../../../configuration/bank/bank.model';
import { BankService } from './../../../configuration/bank/bank.service';
import { SchoolViewModel } from './../../../configuration/school/school.model';


@Component({
  selector: 'app-hr-employee-bank',
  templateUrl: './bank.component.html',
  styleUrls: ['./bank.component.scss']
})
export class EmployeeBankComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'bankName',
                                'bankAddress',
                                'accountNumber',
                                'accountOwner',
                              'action' ];
  dataSource = new MatTableDataSource();
  listBank: BankViewModel[];
  listSchool: SchoolViewModel[];

  constructor(
    private dialog: MatDialog,
    private employeeBankService: EmployeeBankService,
    private bankService: BankService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeBankService.getPermission();
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
    this.employeeBankService.confirmDelete(id, version).subscribe((response: ResponseModel) => {
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
    this.employeeBankService.getList(this.paging, this.searchText, this.employee.id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.TotalItems;
      }
      this.isLoading = false;
    });
  }

  public getBank() {
    this.isLoading = true;
    this.bankService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listBank = response.result;
      }
      this.isLoading = false;
    });
  }

  private showFormModal(id?: number) {
    const modalRef = this.dialog.open(EmployeeBankFormComponent, {
      disableClose: true,
      panelClass: 'mat-modal-md',
      data: {
        isPopup: true,
        itemId: id,
        employeeId: this.employee.id,
        listBank: this.listBank,
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
