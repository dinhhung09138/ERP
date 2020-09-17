import { NgModule } from '@angular/core';

import { SystemComponent } from './system.component';
import { SystemRouterModule } from './system-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { EmployeeService } from '../human-resources/employee/employee.service';
import { RoleService } from './role/role.service';
import { AccountResolver } from './account/account.resolver';

@NgModule({
  declarations: [
    SystemComponent
  ],
  imports: [
    SharedModule,
    SystemRouterModule
  ],
  providers: [
    AccountResolver,
    RoleService,
    EmployeeService,
  ]
})
export class SystemModule { }
