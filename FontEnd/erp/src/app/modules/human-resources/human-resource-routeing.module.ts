import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HumanResourcesComponent } from './human-resources.component';
const routes: Routes = [
  {
    path: '',
    component: HumanResourcesComponent,
    children:[
      {
        path: 'employee',
        loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule),
        data: { title: 'Employee' }
      },
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
