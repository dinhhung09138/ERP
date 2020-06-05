
import { ModelofstudyComponent } from './modelofstudy.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModelofstudyFormComponent } from './modelofstudy-form/modelofstudy-form.component';
import { ModelofstudyListComponent } from './modelofstudy-list/modelofstudy-list.component';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';

const route: Routes = [
    {
      path: '',
      component: ModelofstudyComponent,
      data: { title: 'Modelofstudy' }
    }
  ]
  
  @NgModule({
    declarations: [
      ModelofstudyComponent,
      ModelofstudyFormComponent,
      ModelofstudyListComponent,
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
  export class ModelofstudyModule { }