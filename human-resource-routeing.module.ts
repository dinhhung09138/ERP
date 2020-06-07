import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
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
        path: 'commendation',
        loadChildren: () => import('./commendation/commendation.module').then(m => m.CommendationModule),
        pathMatch: 'full'
      },
      {
        path: 'province',
        loadChildren: () => import('./province/province.module').then(m => m.ProvinceModule)
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
