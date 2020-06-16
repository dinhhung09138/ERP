import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { DistrictResolver } from './district/district.resolver';
import { ProvinceService } from './province/province.service';
import { DistrictService } from './district/district.service';
import { WardResolver } from './ward/ward.resolver';
@NgModule({
  declarations: [
    HumanResourcesComponent,
  ],
  imports: [
    CommonModule,
    HumanResourceRoutingModule,
  ],
  providers: [
    DistrictResolver,
    WardResolver,
    ProvinceService,
    DistrictService,
  ]
})
export class HumanResourcesModule { }
