import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { EmployeeListComponent } from './employee-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeService } from '../employee.service';
import { FormatDatePipe } from '../../../../core/pipes/format-date.pipe';

const routes: Routes = [
  {
    path: '',
    component: EmployeeListComponent,
    data: { title: 'SCREEN.HR.EMPLOYEE.TITLE' }
  },
];

@NgModule({
  declarations: [
    EmployeeListComponent,
    FormatDatePipe,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    EmployeeService,
  ]
})
export class EmployeeListModule { }
