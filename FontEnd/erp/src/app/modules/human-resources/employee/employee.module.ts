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
import { EmployeeRoutingModule } from './employee-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ListCommendationComponent } from './employee-commendation/list-commendation/list-commendation.component';
import { FormCommendationComponent } from './employee-commendation/form-commendation/form-commendation.component';
import { ListContactComponent } from './employee-contact/list-contact/list-contact.component';
import { FormContactComponent } from './employee-contact/form-contact/form-contact.component';
import { FormContractComponent } from './employee-contract/form-contract/form-contract.component';
import { ListDiciplineComponent } from './employee-dicipline/list-dicipline/list-dicipline.component';
import { FormDiciplineComponent } from './employee-dicipline/form-dicipline/form-dicipline.component';
import { ListEducationComponent } from './employee-education/list-education/list-education.component';
import { FormEducationComponent } from './employee-education/form-education/form-education.component';
import { ListIdentificationComponent } from './employee-identification/list-identification/list-identification.component';
import { FormIdentificationComponent } from './employee-identification/form-identification/form-identification.component';
import { ListInfoComponent } from './employee-info/list-info/list-info.component';
import { FormInfoComponent } from './employee-info/form-info/form-info.component';
import { ListRelationshipComponent } from './employee-relationship/list-relationship/list-relationship.component';
import { FormRelationshipComponent } from './employee-relationship/form-relationship/form-relationship.component';


@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeInfoComponent,
    EmployeeRelationshipComponent,
    EmployeeEducationComponent,
    EmployeeIdentificationComponent,
    EmployeeCommendationComponent,
    EmployeeContactComponent,
    EmployeeContractComponent,
    EmployeeDiciplineComponent,
    ListCommendationComponent,
    FormCommendationComponent,
    ListContactComponent,
    FormContactComponent,
    FormContractComponent,
    ListDiciplineComponent,
    FormDiciplineComponent,
    ListEducationComponent,
    FormEducationComponent,
    ListIdentificationComponent,
    FormIdentificationComponent,
    ListInfoComponent,
    FormInfoComponent,
    ListRelationshipComponent,
    FormRelationshipComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    MatToolbarModule,
    MatTabsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule
  ]
})
export class EmployeeModule { }
