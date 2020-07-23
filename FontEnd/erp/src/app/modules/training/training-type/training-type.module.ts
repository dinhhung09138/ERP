import { NgModule } from '@angular/core';
import { TrainingTypeComponent } from './training-type.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: TrainingTypeComponent,
  }
];

@NgModule({
  declarations: [
    TrainingTypeComponent
  ],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class TrainingTypeModule { }
