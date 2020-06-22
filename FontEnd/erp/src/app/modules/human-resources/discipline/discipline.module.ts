import { NgModule } from '@angular/core';
import { DisciplineComponent } from './discipline.component';
import { Routes, RouterModule } from '@angular/router';
import { DisciplineFormComponent } from './form/form.component';
import { DisciplineService } from './discipline.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

const route: Routes = [
  {
    path: '',
    component: DisciplineComponent,
    data: { title: 'Discipline' }
  }
]

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
  ],
  providers: [
    DisciplineService,
  ]
})
export class DisciplineModule { }
