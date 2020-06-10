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
        path: 'ProfessionalQualification',
        loadChildren: () => import('./professional-qualification/professional-qualification.module').then(m => m.ProfessionalQualificationModule),
        data: { title: 'ProfessionalQualification' }
      },
      {
        path: 'ContractType',
        loadChildren: () => import('./contract-type/contract-type.module').then(m => m.ContractTypeModule),
        data: { title: 'ContractType' }
      },
      {
        path: 'ModelOfStudy',
        loadChildren: () => import('./model-of-study/model-of-study.module').then(m => m.ModelOfStudyModule),
        data: { title: 'ModelOfStudy' }
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
