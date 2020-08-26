import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';


@NgModule({
  declarations: [
    EmployeeComponent,
  ],
  imports: [
    EmployeeRoutingModule,
    SharedModule,
    MatTableModule,
    MatSortModule,
  ],
  providers: [
  ]
})
export class EmployeeModule { }
