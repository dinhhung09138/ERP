import { Component, OnInit, ViewChild } from '@angular/core';
import { ECommendationViewModel } from './ecommendation.model';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-employee-commendation',
  templateUrl: './employee-commendation.component.html',
  styleUrls: ['./employee-commendation.component.css']
})
export class EmployeeCommendationComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  listColumnsName = ["title","money","comment","approvedStatus","action"];

  list: ECommendationViewModel[] = [
    {
      id: 1,
      title: 'VU CHUNG DUNG',
      money: 1,
      comment:'VU CHUNG DUNG',
      approvedStatus: true,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 2,
      title: 'VU CHUNG DUNG',
      money: 2,
      comment:'VU CHUNG DUNG',
      approvedStatus: true,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 3,
      title: 'VU CHUNG DUNG',
      money: 3,
      comment:'VU CHUNG DUNG',
      approvedStatus: true,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 4,
      title: 'VU CHUNG DUNG',
      money: 4,
      comment:'VU CHUNG DUNG',
      approvedStatus: true,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 5,
      title: 'VU CHUNG DUNG',
      money: 5,
      comment:'VU CHUNG DUNG',
      approvedStatus: true,
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
  ];
  dataSource = new MatTableDataSource(this.list);
  constructor() { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  filterTable(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
