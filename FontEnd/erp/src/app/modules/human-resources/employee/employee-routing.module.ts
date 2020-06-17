import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./employee-list/employee-list.module').then(m => m.EmployeeListModule),
        data: { title: 'Employee List' },
      },
      {
        path: 'new',
        loadChildren: () => import('./employee-info/employee-info.module').then(m => m.EmployeeInfoModule),
        pathMatch: 'full',
      },
      {
        path: 'edit/:id',
        loadChildren: () => import('./employee-info/employee-info.module').then(m => m.EmployeeInfoModule),
        pathMatch: 'full',
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeeRoutingModule { }
