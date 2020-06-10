import { Component, OnInit, ViewChild } from '@angular/core';
import { EducationViewModel } from '../e-education.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-list-education',
  templateUrl: './list-education.component.html',
  styleUrls: ['./list-education.component.css']
})
export class ListEducationComponent implements OnInit {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paninator: MatPaginator;

  listColumnsName = ["year", "isActive", "action"];
  list: EducationViewModel[] = [];
  dataSource = new MatTableDataSource(this.list);
  constructor() { }

  ngOnInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paninator;
  }
  filterTable(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
