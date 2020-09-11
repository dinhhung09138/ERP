import { NgModule } from '@angular/core';

import { TrainingComponent } from './training.component';
import { TrainingRouterModule } from './training-router.module';
import { SharedModule } from '../../shared/shared.module';



@NgModule({
  declarations: [
    TrainingComponent
  ],
  imports: [
    SharedModule,
    TrainingRouterModule,
  ]
})
export class TrainingModule { }
