import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { TrainingComponent } from './training.component';

const routes: Routes = [
  {
    path: '',
    component: TrainingComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('../training/dashboard/dashboard.module').then(m => m.DashboardModule),
      },
      {
        path: 'appraise',
        loadChildren: () => import('../training/appraise/appraise.module').then(m => m.AppraiseModule),
      },
      {
        path: 'center',
        loadChildren: () => import('../training/training-center/training-center.module').then(m => m.TrainingCenterModule),
      },
      {
        path: 'lecturer',
        loadChildren: () => import('../training/lecturer/lecturer.module').then(m => m.LecturerModule)
      },
      {
        path: 'specialize',
        loadChildren: () => import('../training/specialize/specialize.module').then(m => m.SpecializeModule),
      },
      {
        path: 'type',
        loadChildren: () => import('../training/training-type/training-type.module').then(m => m.TrainingTypeModule),
      },
      {
        path: 'course',
        loadChildren: () => import('../training/training-course/training-course.module').then(m => m.TrainingCourseModule),
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})

export class TrainingRouterModule { }
