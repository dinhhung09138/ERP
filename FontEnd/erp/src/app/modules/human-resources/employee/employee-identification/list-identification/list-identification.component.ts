import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { IdentificationViewModel } from '../e-identification.model';
import { MatTableDataSource } from '@angular/material/table';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-list-identification',
  templateUrl: './list-identification.component.html',
  styleUrls: ['./list-identification.component.css']
})
export class ListIdentificationComponent implements OnInit {

  @ViewChild(MatSort,{static:true}) sort:MatSort;
  @ViewChild(MatPaginator,{static:true})paginator:MatPaginator;

  listColumnsName = ["code","name","notes","isActive","action"];
  list:IdentificationViewModel[] = [
    {
      id:1,
      code:"DUNG",
      name:"VU CHUNG DUNG",
      notes:"VU CHUNG DUNG",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id:2,
      code:"DUNG",
      name:"VU CHUNG DUNG",
      notes:"VU CHUNG DUNG",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id:3,
      code:"DUNG",
      name:"VU CHUNG DUNG",
      notes:"VU CHUNG DUNG",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id:4,
      code:"DUNG",
      name:"VU CHUNG DUNG",
      notes:"VU CHUNG DUNG",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id:5,
      code:"DUNG",
      name:"VU CHUNG DUNG",
      notes:"VU CHUNG DUNG",
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

  filterTable(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
