import { NgModule } from '@angular/core';
import { EducationComponent } from './education.component';
import { Routes, RouterModule } from '@angular/router';
import { EducationFormComponent } from './form/form.component';
import { EducationService } from './education.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: EducationComponent,
    data: { title: 'Education' }
  }
];

@NgModule({
  declarations: [
    EducationComponent,
    EducationFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    EducationService,
  ]
})
export class EducationModule { }
