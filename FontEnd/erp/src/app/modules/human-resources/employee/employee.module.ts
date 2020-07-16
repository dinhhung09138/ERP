import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeService } from './employee.service';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { EmployeeDetailResolver } from './employee-detail/employee-detail.resolver';
import { EmployeeWorkingStatusService } from '../employee-working-status/employee-working-status.service';


@NgModule({
  declarations: [
    EmployeeComponent,
  ],
  imports: [
    EmployeeRoutingModule,
    SharedModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    EmployeeService,
    EmployeeWorkingStatusService,
    EmployeeDetailResolver,
  ]
})
export class EmployeeModule { }
