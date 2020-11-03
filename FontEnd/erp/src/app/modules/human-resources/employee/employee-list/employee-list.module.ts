import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { EmployeeListComponent } from './employee-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeService } from '../employee.service';
import { PersonalInfoService } from '../employee-info/personal-info/personal-info.service';
import { EmployeeEducationService } from '../employee-info/education/education.service';
import { EmployeeIdentificationService } from '../employee-info/identification/identification.service';
import { EmployeeRelationShipService } from '../employee-info/relationship/relationship.service';

const routes: Routes = [
  {
    path: '',
    component: EmployeeListComponent,
    data: { title: 'SCREEN.HR.EMPLOYEE.TITLE' }
  },
];

@NgModule({
  declarations: [
    EmployeeListComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    EmployeeService,
    PersonalInfoService,
    EmployeeEducationService,
    EmployeeIdentificationService,
    EmployeeEducationService,
    EmployeeRelationShipService,
  ]
})
export class EmployeeListModule { }
