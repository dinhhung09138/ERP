import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { EmployeeInfoResolver } from './employee-info/employee-info.resolver';

const routes: Routes = [
  {
    path: '',
    component: EmployeeComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./employee-list/employee-list.module').then(m => m.EmployeeListModule),
        data: { title: 'Danh sách nhân viên' },
      },
      {
        path: 'new',
        loadChildren: () => import('./employee-info/employee-info.module').then(m => m.EmployeeInfoModule),
        resolve: { data: EmployeeInfoResolver },
      },
      {
        path: 'edit/:id',
        loadChildren: () => import('./employee-info/employee-info.module').then(m => m.EmployeeInfoModule),
        resolve: { data: EmployeeInfoResolver },
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeeRoutingModule { }
