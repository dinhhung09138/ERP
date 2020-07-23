import { NgModule } from '@angular/core';
import { TrainingCourseComponent } from './training-course.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: TrainingCourseComponent,
  }
];

@NgModule({
  declarations: [TrainingCourseComponent],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class TrainingCourseModule { }
