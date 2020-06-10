import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { ECommendationViewModel } from '../e-commendation.model';

@Component({
  selector: 'app-list-commendation',
  templateUrl: './list-commendation.component.html',
  styleUrls: ['./list-commendation.component.css']
})
export class ListCommendationComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  listColumnsName = ["title", "money", "comment", "approvedStatus", "action"];

  list: ECommendationViewModel[] = [];
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
