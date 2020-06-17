import { NgModule } from '@angular/core';
import { EmployeeComponent } from './employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeService } from './employee.service';


@NgModule({
  declarations: [
    EmployeeComponent,
  ],
  imports: [
    EmployeeRoutingModule,
    SharedModule,
  ],
  providers: [
    EmployeeService
  ]
})
export class EmployeeModule { }
