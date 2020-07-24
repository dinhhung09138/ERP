import { NgModule } from '@angular/core';
import { TrainingTypeComponent } from './training-type.component';
import { Routes, RouterModule } from '@angular/router';
import { TrainingTypeFormComponent } from './form/form.component';
import { TrainingTypeService } from './training-type.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: TrainingTypeComponent,
    data: { title: 'Training Type' }
  }
]

@NgModule({
  declarations: [
    TrainingTypeComponent,
    TrainingTypeFormComponent,
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
    TrainingTypeService,
  ]
})
export class TrainingTypeModule { }
