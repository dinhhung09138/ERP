import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import { MaritalStatusService } from './marital-status.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MaritalStatusComponent } from './marital-status.component';
import { MaritalStatusFormComponent } from './form/form.component';

const routes: Routes = [
  {
    path: '',
    component: MaritalStatusComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.MARITAL.TITLE' }
  }
];

@NgModule({
  declarations: [
    MaritalStatusComponent,
    MaritalStatusFormComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    MaritalStatusService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class MaritalStatusModule { }
