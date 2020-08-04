import { AuthenticationGuard } from './../../core/guards/authentication.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
import { DistrictResolver } from './configuration/district/district.resolver';
import { WardResolver } from './configuration/ward/ward.resolver';

const routes: Routes = [
  {
    path: '',
    component: HumanResourcesComponent,
    children: [
      {
        path: 'employee',
        loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule),
        pathMatch: 'full',
      },
      {
        path: 'commendation',
        loadChildren: () => import('./commendation/commendation.module').then(m => m.CommendationModule),
        pathMatch: 'full',
      },
      {
        path: 'discipline',
        loadChildren: () => import('./discipline/discipline.module').then(m => m.DisciplineModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/province',
        loadChildren: () => import('./configuration/province/province.module').then(m => m.ProvinceModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/district',
        loadChildren: () => import('./configuration/district/district.module').then(m => m.DistrictModule),
        resolve: { province: DistrictResolver },
        pathMatch: 'full',
      },
      {
        path: 'configuration/ward',
        loadChildren: () => import('./configuration/ward/ward.module').then(m => m.WardModule),
        resolve: { data: WardResolver },
        pathMatch: 'full',
      },
      {
        path: 'configuration/education',
        loadChildren: () => import('./configuration/education/education.module').then(m => m.EducationModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/model-of-study',
        loadChildren: () => import('./configuration/model-of-study/model-of-study.module').then(m => m.ModelOfStudyModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/identification',
        loadChildren: () => import('./configuration/identification-type/identification-type.module').then(m => m.IdentificationTypeModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/qualification',
        loadChildren: () => import('./configuration/professional-qualification/professional-qualification.module')
          .then(m => m.ProfessionalQualificationModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/ranking',
        loadChildren: () => import('./configuration/ranking/ranking.module').then(m => m.RankingModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/contract-type',
        loadChildren: () => import('./configuration/contract-type/contract-type.module').then(m => m.ContractTypeModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/employee-status',
        loadChildren: () => import('./configuration/employee-working-status/employee-working-status.module')
          .then(m => m.EmployeeWorkingStatusModule),
        pathMatch: 'full'
      },
      {
        path: 'configuration/relationship-type',
        loadChildren: () => import('./configuration/relationship-type/relationship-type.module').then(m => m.RelationshipTypeModule),
        pathMatch: 'full'
      },
      {
        path: 'configuration/approve-status',
        loadChildren: () => import('./configuration/approve-status/approve-status.module').then(m => m.ApproveStatusModule),
        pathMatch: 'full',
      },
      {
        path: 'configuration/religion',
        loadChildren: () => import('./configuration/religion/religion.module').then(m => m.ReligionModule),
        pathMatch: 'full'
      },
      {
        path: 'configuration/nation',
        loadChildren: () => import('./configuration/nation/nation.module').then(m => m.NationModule),
        pathMatch: 'full'
      },
      {
        path: 'configuration/nationality',
        loadChildren: () => import('./configuration/nationality/nationality.module').then(m => m.NationalityModule),
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
