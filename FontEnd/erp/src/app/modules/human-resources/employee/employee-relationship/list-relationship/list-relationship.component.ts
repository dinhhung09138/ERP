import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { RelationshipViewModel } from '../e-relationship.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list-relationship',
  templateUrl: './list-relationship.component.html',
  styleUrls: ['./list-relationship.component.css']
})
export class ListRelationshipComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  listColumnsName = ["fullName", "address", "mobile", "isActive", "action"];
  list: RelationshipViewModel[] = [
    {
      id: 1,
      fullName: "VU CHUNG DUNG",
      address: "Ha Noi",
      mobile: "0912345678",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 2,
      fullName: "VU CHUNG DUNG",
      address: "Ha Noi",
      mobile: "0912345678",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 3,
      fullName: "VU CHUNG DUNG",
      address: "Ha Noi",
      mobile: "0912345678",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 4,
      fullName: "VU CHUNG DUNG",
      address: "Ha Noi",
      mobile: "0912345678",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 5,
      fullName: "VU CHUNG DUNG",
      address: "Ha Noi",
      mobile: "0912345678",
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
