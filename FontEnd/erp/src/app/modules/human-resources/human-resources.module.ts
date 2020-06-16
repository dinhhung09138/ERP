import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { DistrictResolver } from './district/district.resolver';
import { ProvinceService } from './province/province.service';
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
    ProvinceService,
  ]
})
export class HumanResourcesModule { }
