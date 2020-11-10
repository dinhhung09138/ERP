import { MajorService } from './../../configuration/major/major.service';
import { SchoolService } from './../../configuration/school/school.service';
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

import { EmployeeService } from '../employee.service';
import { PersonalInfoComponent } from './personal-info/personal-info.component';
import { EmployeeRelationshipComponent } from './relationship/relationship.component';
import { EmployeeEducationComponent } from './education/education.component';
import { EmployeeEducationFormComponent } from './education/form/form.component';
import { EmployeeEducationService } from './education/education.service';
import { EmployeeIdentificationComponent } from './identification/identification.component';
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
import { EmployeeRelationshipFormComponent } from './relationship/form/form.component';
import { MatSelectModule } from '@angular/material/select';
import { EmployeeIdentificationFormComponent } from './identification/form/form.component';
import { EmployeeIdentificationService } from './identification/identification.service';
import { ProvinceService } from '../../configuration/province/province.service';
import { IdentificationTypeService } from '../../configuration/identification-type/identification-type.service';
import { ModelOfStudyService } from '../../configuration/model-of-study/model-of-study.service';

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
    EmployeeEducationComponent,
    EmployeeEducationFormComponent,
    EmployeeRelationshipComponent,
    EmployeeRelationshipFormComponent,
    EmployeeIdentificationComponent,
    EmployeeIdentificationFormComponent,
    ContractComponent,
    ContactComponent,
    FormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
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
    EmployeeEducationService,
    EmployeeRelationShipService,
    EmployeeIdentificationService,
    PersonalInfoService,
    ProvinceService,
    IdentificationTypeService,
    ModelOfStudyService,
    RankingService,
    EducationService,
    FormatDatePipe,
    ReligionService,
    EthnicityService,
    NationalityService,
    RelationshipTypeService,
    RankingService,
    EducationService,
    SchoolService,
    MajorService,
    ProfessionalQualificationService,
    FormatNumberPipe,
  ]
})

export class EmployeeInfoModule { }
