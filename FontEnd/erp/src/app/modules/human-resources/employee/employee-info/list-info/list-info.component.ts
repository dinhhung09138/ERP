import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { InfoViewModel } from '../e-info.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list-info',
  templateUrl: './list-info.component.html',
  styleUrls: ['./list-info.component.css']
})
export class ListInfoComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  listColumnsName = ["lastName", "firstName", "gender", "dateOfBirth", "isActive", "action"];
  list: InfoViewModel[] = [
    {
      id: 1,
      lastName: "VU",
      firstName: "DUNG",
      gender: true,
      dateOfBirth: new Date(),
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 2,
      lastName: "VU",
      firstName: "DUNG",
      gender: true,
      dateOfBirth: new Date(),
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 3,
      lastName: "VU",
      firstName: "DUNG",
      gender: true,
      dateOfBirth: new Date(),
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 4,
      lastName: "VU",
      firstName: "DUNG",
      gender: true,
      dateOfBirth: new Date(),
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 5,
      lastName: "VU",
      firstName: "DUNG",
      gender: true,
      dateOfBirth: new Date(),
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    }
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
