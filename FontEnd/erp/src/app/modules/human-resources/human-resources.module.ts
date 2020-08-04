import { ApiService } from './../../core/services/api.service';
import { NgModule } from '@angular/core';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { DistrictResolver } from './configuration/district/district.resolver';
import { ProvinceService } from './configuration/province/province.service';
import { DistrictService } from './configuration/district/district.service';
import { WardResolver } from './configuration/ward/ward.resolver';
import { SharedModule } from '../../shared/shared.module';
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
    ProvinceService,
    DistrictService,
  ]
})
export class HumanResourcesModule { }
