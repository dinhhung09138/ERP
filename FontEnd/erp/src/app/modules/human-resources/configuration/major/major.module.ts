import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { MajorComponent } from './major.component';
import { MajorFormComponent } from './form/form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MajorService } from './major.service';

const route: Routes = [
  {
    path: '',
    component: MajorComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.MAJOR.TITLE' }
  }
];

@NgModule({
  declarations: [
    MajorComponent,
    MajorFormComponent
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
    MajorService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class MajorModule { }
