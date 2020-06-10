import { NgModule } from '@angular/core';
import { ModelOfStudyComponent } from './model-of-study.component';
import { Routes, RouterModule } from '@angular/router';
import { ModelOfStudyListComponent } from './model-of-study-list/model-of-study-list.component';
import { ModelOfStudyFormComponent } from './model-of-study-form/model-of-study-form.component';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
const route: Routes = [
    {
      path: '',
      component: ModelOfStudyComponent,
      data: { title: 'ModelOfStudy' }
    }
  ]
  
  @NgModule({
    declarations: [
      ModelOfStudyComponent,
      ModelOfStudyFormComponent,
      ModelOfStudyListComponent,
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
  export class ModelOfStudyModule { }