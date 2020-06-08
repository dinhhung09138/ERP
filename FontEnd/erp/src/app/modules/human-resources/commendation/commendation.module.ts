import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommendationComponent } from './commendation.component';
import { Routes, RouterModule } from '@angular/router';
import { CommendationFormComponent } from './form/form.component';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommendationService } from './commendation.service';
import { HttpClientModule } from '@angular/common/http';

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
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCheckboxModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    RouterModule.forChild(route),
  ],
  providers: [
    CommendationService,
  ]
})
export class CommendationModule { }
