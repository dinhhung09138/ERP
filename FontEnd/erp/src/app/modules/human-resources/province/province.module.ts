import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ProvinceComponent } from './province.component';
import { ProvinceFormComponent } from './province-form/province-form.component';
import { ProvinceListComponent } from './province-list/province-list.component';


const route: Routes = [
  {
    path: '',
    component: ProvinceComponent,
    data: { title: 'Province' }
  }
];

@NgModule({
  declarations: [
    ProvinceComponent,
    ProvinceFormComponent,
    ProvinceListComponent
  ],
  imports: [
    CommonModule,
    MatCheckboxModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    RouterModule.forChild(route)
  ]
})
export class ProvinceModule { }
