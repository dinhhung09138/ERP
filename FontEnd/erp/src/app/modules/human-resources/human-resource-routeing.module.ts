import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
import { CommendationComponent } from './commendation/commendation.component';
import { DistrictResolver } from './district/district.resolver';
import { WardResolver } from './ward/ward.resolver';

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
        loadChildren: () => import('./ward/ward.module').then(m => m.WardModule),
        resolve: { data: WardResolver },
      },
      {
        path: 'configuration/education',
        loadChildren: () => import('./education/education.module').then(m => m.EducationModule),
      },
      {
        path: 'configuration/model-of-study',
        loadChildren: () => import('./model-of-study/model-of-study.module').then(m => m.ModelOfStudyModule),
      },
      {
        path: 'configuration/identification',
        loadChildren: () => import('./identification-type/identification-type.module').then(m => m.IdentificationTypeModule),
      },
      {
        path: 'configuration/qualification',
        loadChildren: () => import('./professional-qualification/professional-qualification.module')
          .then(m => m.ProfessionalQualificationModule),
      },
      {
        path: 'configuration/ranking',
        loadChildren: () => import('./ranking/ranking.module').then(m => m.RankingModule),
      },
      {
        path: 'configuration/contract-type',
        loadChildren: () => import('./contract-type/contract-type.module').then(m => m.ContractTypeModule),
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
