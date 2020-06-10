import { Component, OnInit, ViewChild } from '@angular/core';
import { DiciplineViewModel } from '../e-dicipline.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-list-dicipline',
  templateUrl: './list-dicipline.component.html',
  styleUrls: ['./list-dicipline.component.css']
})
export class ListDiciplineComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  listColumnsName = ["money", "comment", "isActive", "action"];
  list: DiciplineViewModel[] = [];
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
