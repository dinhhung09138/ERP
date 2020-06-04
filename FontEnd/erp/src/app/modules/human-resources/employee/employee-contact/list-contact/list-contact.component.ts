import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { EContactViewModel } from '../e-contact.model';

@Component({
  selector: 'app-list-contact',
  templateUrl: './list-contact.component.html',
  styleUrls: ['./list-contact.component.css']
})
export class ListContactComponent implements OnInit {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  listColumnsName = ["phone","mobile","email","skyper","temporaryaddress","permanentaddress","isActive","action"];

  list: EContactViewModel[] = [
    {
      id: 1,
      phone:"0987654321",
      mobile: "0987654321",
      email: "abc@gmail.com",
      skyper: "abc@gmail.com",
      temporaryaddress:"abc@gmail.com",
      permanentaddress:"abc@gmail.com",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 2,
      phone:"0987654321",
      mobile: "0987654321",
      email: "abc@gmail.com",
      skyper: "abc@gmail.com",
      temporaryaddress:"abc@gmail.com",
      permanentaddress:"abc@gmail.com",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 3,
      phone:"0987654321",
      mobile: "0987654321",
      email: "abc@gmail.com",
      skyper: "abc@gmail.com",
      temporaryaddress:"abc@gmail.com",
      permanentaddress:"abc@gmail.com",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 4,
      phone:"0987654321",
      mobile: "0987654321",
      email: "abc@gmail.com",
      skyper: "abc@gmail.com",
      temporaryaddress:"abc@gmail.com",
      permanentaddress:"abc@gmail.com",
      isActive: true,
      createBy: null,
      createDate: new Date(),
      updateBy: null,
      updateDate: new Date(),
    },
    {
      id: 5,
      phone:"0987654321",
      mobile: "0987654321",
      email: "abc@gmail.com",
      skyper: "abc@gmail.com",
      temporaryaddress:"abc@gmail.com",
      permanentaddress:"abc@gmail.com",
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
