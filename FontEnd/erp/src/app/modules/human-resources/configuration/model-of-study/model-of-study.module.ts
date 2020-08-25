import { NgModule } from '@angular/core';
import { ModelOfStudyComponent } from './model-of-study.component';
import { Routes, RouterModule } from '@angular/router';
import { ModelOfStudyFormComponent } from './form/form.component';
import { ModelOfStudyService } from './model-of-study.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

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
