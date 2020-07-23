import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingCenterComponent } from './training-center.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: TrainingCenterComponent,
  }
];

@NgModule({
  declarations: [
    TrainingCenterComponent
  ],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class TrainingCenterModule { }
