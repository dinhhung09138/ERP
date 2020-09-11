import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import { NationalityService } from './nationality.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NationalityComponent } from './nationality.component';
import { NationalityFormComponent } from './form/form.component';

const routes: Routes = [
  {
    path: '',
    component: NationalityComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.NATIONALITY.TITLE' }
  }
];

@NgModule({
  declarations: [
    NationalityComponent,
    NationalityFormComponent],
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
    NationalityService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class NationalityModule { }
