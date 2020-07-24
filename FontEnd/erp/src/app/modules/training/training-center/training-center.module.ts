import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainingCenterComponent } from './training-center.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { TrainingCenterService } from './training-center.service';
import { TrainingCenterFormComponent } from './form/form.component';

const routes: Routes = [
  {
    path: '',
    component: TrainingCenterComponent,
  },
];

@NgModule({
  declarations: [
    TrainingCenterComponent,
    TrainingCenterFormComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [TrainingCenterService],
})
export class TrainingCenterModule {}
