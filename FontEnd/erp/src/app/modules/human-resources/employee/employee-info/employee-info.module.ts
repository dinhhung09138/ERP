import { NgModule } from '@angular/core';
import { EmployeeInfoComponent } from './employee-info.component';
import { Routes, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatRadioModule } from '@angular/material/radio';
import { EmployeeService } from '../employee.service';
import { NgSelectModule } from '@ng-select/ng-select';
import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { RelationshipComponent } from './relationship/relationship.component';
import { EducationComponent } from './education/education.component';
import { IdentificationComponent } from './identification/identification.component';
import { ContractComponent } from './contract/contract.component';
import { ContactComponent } from './contact/contact.component';
import { FormComponent } from './contact/form/form.component';
import { SharedModule } from '../../../../shared/shared.module';
import { AppDateAdapter } from '../../../../core/helpers/format-datepicker.helper';
import { FormatDatePipe } from '../../../../core/pipes/format-date.pipe';
import { PersonalInfoService } from './personal-info/personal-info.service';
import { EthnicityService } from '../../configuration/ethnicity/ethnicity.service';
import { NationalityService } from '../../configuration/nationality/nationality.service';
import { EducationService } from '../../configuration/education/education.service';
import { ProfessionalQualificationService } from '../../configuration/professional-qualification/professional-qualification.service';
import { ReligionService } from '../../configuration/religion/religion.service';

const routes: Routes = [
  {
    path: '',
    component: EmployeeInfoComponent,
    data: { title: 'SCREEN.HR.EMPLOYEE.FORM.TITLE' }
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
    MatRadioModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatIconModule,
  ],
  providers: [
    AppDateAdapter,
    EmployeeService,
    PersonalInfoService,
    FormatDatePipe,
    ReligionService,
    EthnicityService,
    NationalityService,
    EducationService,
    ProfessionalQualificationService,
  ]
})

export class EmployeeInfoModule { }
