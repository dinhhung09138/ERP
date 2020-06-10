import { ProfessionalQualificationFormComponent } from './professional-qualification-form/professional-qualification-form.component';
import { ProfessionalQualificationListComponent } from './professional-qualification-list/professional-qualification-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { ProfessionalQualificationComponent } from './professional-qualification.component';
import { Routes, RouterModule } from '@angular/router';


const route: Routes = [
    {
      path: '',
      component: ProfessionalQualificationComponent,
      data: { title: 'ProfessionalQualification' }
    }
  ]
  
  @NgModule({
    declarations: [
      ProfessionalQualificationComponent,
      ProfessionalQualificationFormComponent,
      ProfessionalQualificationListComponent,
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
  export class ProfessionalQualificationModule { }