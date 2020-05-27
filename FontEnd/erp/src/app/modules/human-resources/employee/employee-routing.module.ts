import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeContactComponent } from './employee-contact/employee-contact.component';
import { EmployeeRelationshipComponent } from './employee-relationship/employee-relationship.component';
import { EmployeeInfoComponent } from './employee-info/employee-info.component';
import { EmployeeContractComponent } from './employee-contract/employee-contract.component';
import { EmployeeDiciplineComponent } from './employee-dicipline/employee-dicipline.component';
import { EmployeeEducationComponent } from './employee-education/employee-education.component';
import { EmployeeIdentificationComponent } from './employee-identification/employee-identification.component';
import { EmployeeCommendationComponent } from './employee-commendation/employee-commendation.component';

const routes: Routes = [
  {
    path: 'contact',
    component: EmployeeContactComponent,
    pathMatch: 'full',
  },
  {
    path: 'relationship',
    component: EmployeeRelationshipComponent,
    pathMatch: 'full',
  },
  {
    path: 'info',
    component: EmployeeInfoComponent,
    pathMatch: 'full',
  },
  {
    path: 'contract',
    component: EmployeeContractComponent,
    pathMatch: 'full',
  },
  {
    path: 'dicioline',
    component: EmployeeDiciplineComponent,
    pathMatch: 'full',
  },
  {
    path: 'education',
    component: EmployeeEducationComponent,
    pathMatch: 'full',
  },
  {
    path: 'indentification',
    component: EmployeeIdentificationComponent,
    pathMatch: 'full',
  },
  {
    path: 'commendation',
    component: EmployeeCommendationComponent,
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeeRoutingModule { }
