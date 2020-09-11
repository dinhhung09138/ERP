import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

import { DisciplineComponent } from './discipline.component';
import { DisciplineFormComponent } from './form/form.component';
import { DisciplineService } from './discipline.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: DisciplineComponent,
    data: { title: 'SCREEN.HR.DISCIPLINE.TITLE' }
  }
];

@NgModule({
  declarations: [
    DisciplineComponent,
    DisciplineFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    DisciplineService,
  ]
})
export class DisciplineModule { }
