import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
import { CommendationComponent } from './commendation/commendation.component';
import { DistrictResolver } from './district/district.resolver';

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
        path: 'discipline',
        loadChildren: () => import('./discipline/discipline.module').then(m => m.DisciplineModule)
      },
      {
        path: 'configuration/province',
        loadChildren: () => import('./province/province.module').then(m => m.ProvinceModule)
      },
      {
        path: 'configuration/district',
        loadChildren: () => import('./district/district.module').then(m => m.DistrictModule),
        resolve: { province: DistrictResolver },
      },
      {
        path: 'configuration/ward',
        loadChildren: () => import('./ward/ward.module').then(m => m.WardModule)
      },
      {
        path: 'configuration/approve-status',
        loadChildren: () => import('./approve-status/approve-status.module').then(m => m.ApproveStatusModule)
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
