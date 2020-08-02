import { ApiService } from './../../core/services/api.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { DistrictResolver } from './configuration/district/district.resolver';
import { ProvinceService } from './configuration/province/province.service';
import { DistrictService } from './configuration/district/district.service';
import { WardResolver } from './configuration/ward/ward.resolver';
@NgModule({
  declarations: [
    HumanResourcesComponent,
  ],
  imports: [
    CommonModule,
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
