import { NgModule } from '@angular/core';
import { ProfessionalQualificationComponent } from './professional-qualification.component';
import { Routes, RouterModule } from '@angular/router';
import { ProfessionalQualificationFormComponent } from './form/form.component';
import { ProfessionalQualificationService } from './professional-qualification.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

const route: Routes = [
  {
    path: '',
    component: ProfessionalQualificationComponent,
    data: { title: 'Professional Qualification' }
  }
]

@NgModule({
  declarations: [
    ProfessionalQualificationComponent,
    ProfessionalQualificationFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    ProfessionalQualificationService,
  ]
})
export class ProfessionalQualificationModule { }
