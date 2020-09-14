import { Component, OnInit } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';

import { AccountViewModel } from './account.model';
import { AccountService } from './account.service';
import { PagingModel } from '../../../core/models/paging.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent implements OnInit {

  isLoading = false;

  paging = new PagingModel();
  searchText = '';
  currentPageSize = this.paging.pageSize;

  listColumnsName: string[] = ['name', 'description', 'isActive', 'action'];
  dataSource = new MatTableDataSource();

  listModuleData: AccountViewModel[];

  constructor(
    private accountService: AccountService,
  ) { }

  ngOnInit(): void {
  }

}
