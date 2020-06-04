import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { EContactViewModel } from './e-contact.model';

@Component({
  selector: 'app-employee-contact',
  templateUrl: './employee-contact.component.html',
  styleUrls: ['./employee-contact.component.css']
})
export class EmployeeContactComponent implements OnInit {

  
  constructor() { }

  ngOnInit(): void {
    
  }
  
}
