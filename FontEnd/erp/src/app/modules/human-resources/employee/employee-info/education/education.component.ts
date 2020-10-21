import { Component, Input, OnInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';

import { EmployeeViewModel } from '../../employee.model';
import { PermissionViewModel } from '../../../../../core/models/permission.model';
import { PagingModel } from '../../../../../core/models/paging.model';

import { EmployeeEducationService } from './education.service';
import { EmployeeEducationFormComponent } from './form/form.component';
import { ResponseModel } from '../../../../../core/models/response.model';
import { ResponseStatus } from '../../../../../core/enums/response-status.enum';
import { ProvinceService } from '../../../configuration/province/province.service';
import { ProvinceViewModel } from '../../../configuration/province/province.model';


@Component({
  selector: 'app-education',
  templateUrl: './education.component.html',
  styleUrls: ['./education.component.scss']
})
export class EmployeeEducationComponent implements OnInit {

  @Input() employee: EmployeeViewModel;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  permission = new PermissionViewModel();
  isLoading = false;
  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = [ 'identificationTypeName', 'code', 'expirationDate', 'placeName', 'notes', 'action' ];
  dataSource = new MatTableDataSource();

  constructor() { }

  ngOnInit(): void {
  }

}
