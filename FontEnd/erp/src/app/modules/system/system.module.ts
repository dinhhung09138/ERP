import { NgModule } from '@angular/core';
import { SystemComponent } from './system.component';
import { SystemRouterModule } from './system-routing.module';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
  declarations: [
    SystemComponent
  ],
  imports: [
    SharedModule,
    SystemRouterModule
  ]
})
export class SystemModule { }
