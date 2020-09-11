import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

import { ModelOfStudyComponent } from './model-of-study.component';
import { ModelOfStudyFormComponent } from './form/form.component';
import { ModelOfStudyService } from './model-of-study.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ModelOfStudyComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.MODEL_OF_STUDY.TITLE' }
  }
];

@NgModule({
  declarations: [
    ModelOfStudyComponent,
    ModelOfStudyFormComponent,
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
    ModelOfStudyService,
  ]
})
export class ModelOfStudyModule { }
