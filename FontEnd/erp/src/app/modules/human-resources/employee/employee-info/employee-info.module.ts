import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeInfoComponent } from './employee-info.component';
import { Routes, RouterModule } from '@angular/router';
import { AppDateAdapter } from 'src/app/core/helpers/format-datepicker.helper';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { EmployeeService } from '../employee.service';
import { DatetimePipe } from 'src/app/core/pipes/datetime.pipe';
import { NgSelectModule } from '@ng-select/ng-select';
import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { RelationshipComponent } from './relationship/relationship.component';
import { EducationComponent } from './education/education.component';
import { IdentificationComponent } from './identification/identification.component';
import { ContractComponent } from './contract/contract.component';
import { ContactComponent } from './contact/contact.component';
import { FormComponent } from './contact/form/form.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeInfoComponent,
  }
];

@NgModule({
  declarations: [
    EmployeeInfoComponent,
    PersonalInfoComponent,
    RelationshipComponent,
    EducationComponent,
    IdentificationComponent,
    ContractComponent,
    ContactComponent,
    FormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    NgSelectModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatIconModule,
  ],
  providers: [
    AppDateAdapter,
    EmployeeService,
    DatetimePipe,
  ]
})
export class EmployeeInfoModule { }
