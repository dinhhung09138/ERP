import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HumanResourcesComponent } from './human-resources.component';
import { HumanResourceRoutingModule } from './human-resource-routeing.module';
import { CommendationComponent } from './commendation/commendation.component';

@NgModule({
  declarations: [
    HumanResourcesComponent,
    CommendationComponent
  ],
  imports: [
    CommonModule,
    HumanResourceRoutingModule
  ],
})
export class HumanResourcesModule { }
