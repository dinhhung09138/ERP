import { NgModule } from '@angular/core';
import { WardComponent } from './ward.component';
import { Routes, RouterModule } from '@angular/router';
import { WardFormComponent } from './form/form.component';
import { WardService } from './ward.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProvinceService } from '../province/province.service';
import { DistrictService } from '../district/district.service';

const route: Routes = [
  {
    path: '',
    component: WardComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.WARD.TITLE' }
  }
];

@NgModule({
  declarations: [
    WardComponent,
    WardFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    NgSelectModule,
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    WardService,
    ProvinceService,
    DistrictService,
    { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} }
  ]
})
export class WardModule { }
