import { NgModule } from '@angular/core';
import { DistrictComponent } from './district.component';
import { Routes, RouterModule } from '@angular/router';
import { DistrictFormComponent } from './form/form.component';
import { DistrictService } from './district.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProvinceService } from '../province/province.service';

const route: Routes = [
  {
    path: '',
    component: DistrictComponent,
    data: { title: 'Quận/Huyện' }
  }
];

@NgModule({
  declarations: [
    DistrictComponent,
    DistrictFormComponent,
  ],
  imports: [
    SharedModule,
    NgSelectModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
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
