import { NgModule } from '@angular/core';
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
import { NgSelectModule } from '@ng-select/ng-select';

import { EmployeeService } from '../employee.service';
import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { EmployeeRelationshipComponent } from './relationship/relationship.component';
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
import { EmployeeInfoComponent } from './employee-info.component';
import { ProfessionalQualificationService } from '../../configuration/professional-qualification/professional-qualification.service';
import { ReligionService } from '../../configuration/religion/religion.service';
import { FormatNumberPipe } from '../../../../core/pipes/format-number.pipe';
import { EmployeeRelationShipService } from './relationship/relationship.service';
import { RelationshipTypeService } from '../../configuration/relationship-type/relationship-type.service';
import { RankingService } from '../../configuration/ranking/ranking.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeRelationshipFormComponent } from './relationship/form/form.component';
import { MatSelectModule } from '@angular/material/select';

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
    EmployeeRelationshipComponent,
    EmployeeRelationshipFormComponent,
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
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatIconModule,
  ],
  providers: [
    AppDateAdapter,
    EmployeeService,
    EmployeeRelationShipService,
    PersonalInfoService,
    FormatDatePipe,
    ReligionService,
    EthnicityService,
    NationalityService,
    RelationshipTypeService,
    RankingService,
    EducationService,
    ProfessionalQualificationService,
    FormatNumberPipe,
  ]
})

export class EmployeeInfoModule { }
