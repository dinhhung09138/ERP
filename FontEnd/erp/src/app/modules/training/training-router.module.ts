import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TrainingComponent } from './training.component';
import { PageNotFoundComponent } from '../../shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '',
    component: TrainingComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('../training/dashboard/dashboard.module').then(m => m.DashboardModule),
        pathMatch: 'full',
      },
      {
        path: 'appraise',
        loadChildren: () => import('../training/appraise/appraise.module').then(m => m.AppraiseModule),
        pathMatch: 'full',
      },
      {
        path: 'center',
        loadChildren: () => import('../training/training-center/training-center.module').then(m => m.TrainingCenterModule),
        pathMatch: 'full',
      },
      {
        path: 'lecturer',
        loadChildren: () => import('../training/lecturer/lecturer.module').then(m => m.LecturerModule),
        pathMatch: 'full',
      },
      {
        path: 'specialize',
        loadChildren: () => import('../training/specialize/specialize.module').then(m => m.SpecializeModule),
        pathMatch: 'full',
      },
      {
        path: 'type',
        loadChildren: () => import('../training/training-type/training-type.module').then(m => m.TrainingTypeModule),
        pathMatch: 'full',
      },
      {
        path: 'course',
        loadChildren: () => import('../training/training-course/training-course.module').then(m => m.TrainingCourseModule),
        pathMatch: 'full',
      },
      {
        path: '**',
        component: PageNotFoundComponent,
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
