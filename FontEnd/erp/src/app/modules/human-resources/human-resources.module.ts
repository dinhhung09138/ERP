import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
@NgModule({
  declarations: [
    HumanResourcesComponent
  ],
  imports: [
    CommonModule,
    HumanResourceRoutingModule,
  ],
})
export class HumanResourcesModule { }
