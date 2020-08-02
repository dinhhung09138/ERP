import { NgModule } from '@angular/core';
import { ProfessionalQualificationComponent } from './professional-qualification.component';
import { Routes, RouterModule } from '@angular/router';
import { ProfessionalQualificationFormComponent } from './form/form.component';
import { ProfessionalQualificationService } from './professional-qualification.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: ProfessionalQualificationComponent,
    data: { title: 'Trình độ chuyên môn' }
  }
];

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
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    ProfessionalQualificationService,
  ]
})
export class ProfessionalQualificationModule { }
