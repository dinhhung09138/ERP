import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
import { CommendationComponent } from './commendation/commendation.component';

const routes: Routes = [
  {
    path: '',
    component: HumanResourcesComponent,
    children: [
      {
        path: 'employee',
        loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule),
        data: { title: 'Employee' }
      },
      {
        path: 'modelofstudy',
        loadChildren: () => import('./modelofstudy/modelofstudy.module').then(m => m.ModelofstudyModule),
        pathMatch: 'Modelofstudy'
      },
      {
        path: 'commendation',
        loadChildren: () => import('./commendation/commendation.module').then(m => m.CommendationModule),
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})

export class HumanResourceRoutingModule { }
