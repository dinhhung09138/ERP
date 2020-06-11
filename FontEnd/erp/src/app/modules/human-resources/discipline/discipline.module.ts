import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DisciplineComponent } from './discipline.component';
import { FormComponent } from './form/form.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { TableLoadingComponent } from 'src/app/shared/components/table-loading/table-loading.component';
import { DisciplineService } from './discipline.service';

const routes: Routes = [
  {
    path: '',
    component: DisciplineComponent
  }
];


@NgModule({
  declarations: [
    DisciplineComponent,
    FormComponent,
    TableLoadingComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    RouterModule.forChild(routes),
  ],
  providers: [
    DisciplineService,
  ]
})
export class DisciplineModule { }
