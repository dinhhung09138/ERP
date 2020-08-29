import { EthnicityService } from './ethnicity.service';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from 'src/app/shared/shared.module';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { EthnicityComponent } from './ethnicity.component';
import { EthnicityFormComponent } from './form/form.component';


const routes: Routes = [
  {
    path: '',
    component: EthnicityComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.ETHNICITY.TITLE' }
  }
];


@NgModule({
  declarations: [
    EthnicityComponent,
    EthnicityFormComponent
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
    EthnicityService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class EthnicityModule { }
