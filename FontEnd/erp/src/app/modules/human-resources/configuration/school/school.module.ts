import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { SchoolComponent } from './school.component';
import { SchoolFormComponent } from './form/form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SchoolService } from './school.service';

const route: Routes = [
  {
    path: '',
    component: SchoolComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.SCHOOL.TITLE' }
  }
];

@NgModule({
  declarations: [
    SchoolComponent,
    SchoolFormComponent
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
    SchoolService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class SchoolModule { }
