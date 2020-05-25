import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeContactComponent } from './employee-contact/employee-contact.component';
import { EmployeeRelationshipComponent } from './employee-relationship/employee-relationship.component';
import { EmployeeInfoComponent } from './employee-info/employee-info.component';

const routes: Routes = [
  {
    path: '/contact',
    component: EmployeeContactComponent,
    pathMatch: 'full',
  },
  {
    path: '/relationship',
    component: EmployeeRelationshipComponent,
    pathMatch: 'full',
  },
  {
    path: '/info',
    component: EmployeeInfoComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeeRoutingModule { }
