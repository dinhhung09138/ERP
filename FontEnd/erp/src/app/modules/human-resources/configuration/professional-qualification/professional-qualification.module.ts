import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { ProfessionalQualificationComponent } from './professional-qualification.component';
import { ProfessionalQualificationFormComponent } from './form/form.component';
import { ProfessionalQualificationService } from './professional-qualification.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ProfessionalQualificationComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.QUALIFICATION.TITLE' }
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
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class ProfessionalQualificationModule { }
