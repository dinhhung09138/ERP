import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommendationComponent } from './commendation.component';
import { Routes, RouterModule } from '@angular/router';
import { CommendationFormComponent } from './form/form.component';
import { CommendationListComponent } from './list/list.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const route: Routes = [
  {
    path: '',
    component: CommendationComponent,
    data: { title: 'Commendation' }
  }
]

@NgModule({
  declarations: [
    CommendationComponent,
    CommendationFormComponent,
    CommendationListComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    RouterModule.forChild(route),
  ]
})
export class CommendationModule { }
