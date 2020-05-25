import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeComponent } from './employee.component';
import { EmployeeInfoComponent } from './employee-info/employee-info.component';
import { EmployeeRelationshipComponent } from './employee-relationship/employee-relationship.component';
import { EmployeeEducationComponent } from './employee-education/employee-education.component';
import { EmployeeIdentificationComponent } from './employee-identification/employee-identification.component';
import { EmployeeCommendationComponent } from './employee-commendation/employee-commendation.component';
import { EmployeeContactComponent } from './employee-contact/employee-contact.component';
import { EmployeeContractComponent } from './employee-contract/employee-contract.component';
import { EmployeeDiciplineComponent } from './employee-dicipline/employee-dicipline.component';



@NgModule({
  declarations: [EmployeeComponent, EmployeeInfoComponent, EmployeeRelationshipComponent, EmployeeEducationComponent, EmployeeIdentificationComponent, EmployeeCommendationComponent, EmployeeContactComponent, EmployeeContractComponent, EmployeeDiciplineComponent],
  imports: [
    CommonModule
  ]
})
export class EmployeeModule { }
