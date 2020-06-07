import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ProvinceViewModel } from '../province.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-province-list',
  templateUrl: './province-list.component.html',
  styleUrls: ['./province-list.component.css']
})
export class ProvinceListComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  listColumnsName: string[] = ['name', 'updateBy', 'Action'];

  list: ProvinceViewModel[] = [
    {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
    }, {
      name: 'Cu ty',
      updateBy: 'Tuan hai',
      UpdateDate: new Date(),
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
