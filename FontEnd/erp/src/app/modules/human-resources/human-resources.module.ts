import { NgModule } from '@angular/core';

import { ApiService } from './../../core/services/api.service';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { DistrictResolver } from './configuration/district/district.resolver';
import { ProvinceService } from './configuration/province/province.service';
import { DistrictService } from './configuration/district/district.service';
import { WardResolver } from './configuration/ward/ward.resolver';
import { SharedModule } from '../../shared/shared.module';
import { EmployeeInfoResolver } from './employee/employee-info/employee-info.resolver';
import { EmployeeWorkingStatusService } from './configuration/employee-working-status/employee-working-status.service';
import { PositionService } from './position/position.service';

@NgModule({
  declarations: [
    HumanResourcesComponent,
  ],
  imports: [
    SharedModule,
    HumanResourceRoutingModule,
  ],
  providers: [
    ApiService,
    DistrictResolver,
    WardResolver,
    EmployeeInfoResolver,
    ProvinceService,
    DistrictService,
    PositionService,
    EmployeeWorkingStatusService,
  ]
})
export class HumanResourcesModule { }
