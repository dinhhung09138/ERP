import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

import { ProvinceService } from '../province/province.service';
import { DistrictComponent } from './district.component';
import { DistrictFormComponent } from './form/form.component';
import { DistrictService } from './district.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: DistrictComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.DISTRICT.TITLE' }
  }
];

@NgModule({
  declarations: [
    DistrictComponent,
    DistrictFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatSelectModule,
    MatIconModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    DistrictService,
    ProvinceService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} },
  ]
})
export class DistrictModule { }
