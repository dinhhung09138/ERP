import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

import { CertificatedComponent } from './certificated.component';
import { CertificatedFormComponent } from './form/form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { CertificatedService } from './certificated.service';

const route: Routes = [
  {
    path: '',
    component: CertificatedComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.CERTIFICATED.TITLE' }
  }
];

@NgModule({
  declarations: [
    CertificatedComponent,
    CertificatedFormComponent
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
    CertificatedService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class CertificatedModule { }
