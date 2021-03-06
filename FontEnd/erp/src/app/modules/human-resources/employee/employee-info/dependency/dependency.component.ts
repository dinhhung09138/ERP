import { Component, Input, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { PagingModel } from '../../../../../core/models/paging.model';
import { EmployeeViewModel } from '../../employee.model';
import { EmployeeDependencyService } from './dependency.service';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { EmployeeDependencyFormComponent } from './form/form.component';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { RelationshipTypeService } from '../../../configuration/relationship-type/relationship-type.service';
import { RelationshipTypeViewModel } from '../../../configuration/relationship-type/relationship-type.model';

@Component({
  selector: 'app-hr-employee-dependency',
  templateUrl: './dependency.component.html',
  styleUrls: ['./dependency.component.scss']
})
export class EmployeeDependencyComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true}) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'fullName', 'relationshipTypeName', 'dateOfBirth', 'action' ];
  dataSource = new MatTableDataSource();
  listRelationShip: RelationshipTypeViewModel[];

  constructor(
    private dialog: MatDialog,
    private employeeDependencyService: EmployeeDependencyService,
    private relationshipTypeService: RelationshipTypeService,
  ) { }

  ngOnInit(): void {
    this.permission = this.employeeDependencyService.getPermission();
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
    this.employeeDependencyService.confirmDelete(id, version).subscribe((response: ResponseModel) => {
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
    this.employeeDependencyService.getList(this.paging, this.searchText, this.employee.id).subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.dataSource.data = response.result.items;
        this.paging.length = response.result.TotalItems;
      }
      this.isLoading = false;
    });
  }

  public getListRelationshipType() {
    this.isLoading = true;
    this.relationshipTypeService.getDropdown().subscribe((response: ResponseModel) => {
      if (response && response.responseStatus === ResponseStatus.success) {
        this.listRelationShip = response.result;
      }
      this.isLoading = false;
    });
  }

  private showFormModal(id?: number) {
    const modalRef = this.dialog.open(EmployeeDependencyFormComponent, {
      disableClose: true,
      panelClass: 'mat-modal-md',
      data: {
        isPopup: true,
        listRelationShip: this.listRelationShip,
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
