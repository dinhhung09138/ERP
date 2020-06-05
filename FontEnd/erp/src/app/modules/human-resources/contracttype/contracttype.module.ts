
import { ContracttypeComponent } from './contracttype.component';
import { NgModule } from '@angular/core';
import { ContracttypeFormComponent } from './contracttype-form/contracttype-form.component';
import { ContracttypeListComponent } from './contracttype-list/contracttype-list.component';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { RouterModule, Routes } from '@angular/router';

const route: Routes = [
    {
      path: '',
      component: ContracttypeComponent,
      data: { title: 'Contracttype' }
    }
  ]
  
  @NgModule({
    declarations: [
      ContracttypeComponent,
      ContracttypeFormComponent,
      ContracttypeListComponent,
    ],
    imports: [
      CommonModule,
      MatCheckboxModule,
      MatSortModule,
      MatPaginatorModule,
      MatTableModule,
      RouterModule.forChild(route),
    ]
  })
  export class ContracttypeModule { }