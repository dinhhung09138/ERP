import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { EmployeeDetailResolver } from './employee-detail/employee-detail.resolver';

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
        loadChildren: () => import('./employee-detail/employee-detail.module').then(m => m.EmployeeDetailModule),
        resolve: { data: EmployeeDetailResolver },
        pathMatch: 'full',
      },
      {
        path: 'edit/:id',
        loadChildren: () => import('./employee-detail/employee-detail.module').then(m => m.EmployeeDetailModule),
        resolve: { data: EmployeeDetailResolver },
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
