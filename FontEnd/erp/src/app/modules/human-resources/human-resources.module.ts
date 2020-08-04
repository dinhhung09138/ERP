import { MainMenuComponent } from './../../shared/components/main-menu/main-menu.component';
import { FooterComponent } from './../../shared/components/footer/footer.component';
import { HeaderComponent } from './../../shared/components/header/header.component';
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
    HeaderComponent,
    FooterComponent,
    MainMenuComponent,
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
