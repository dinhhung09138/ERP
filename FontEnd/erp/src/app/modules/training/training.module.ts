import { NgModule } from '@angular/core';
import { TrainingComponent } from './training.component';
import { TrainingRouterModule } from './training-router.module';



@NgModule({
  declarations: [
    TrainingComponent
  ],
  imports: [
    TrainingRouterModule,
  ]
})
export class TrainingModule { }
