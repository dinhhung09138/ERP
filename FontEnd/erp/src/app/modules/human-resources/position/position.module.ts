import { NgModule } from '@angular/core';
import { PositionComponent } from './position.component';
import { Routes, RouterModule } from '@angular/router';
import { PositionFormComponent } from './form/form.component';
import { PositionService } from './position.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: PositionComponent,
    data: { title: 'Position' }
  }
];

@NgModule({
  declarations: [
    PositionComponent,
    PositionFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    PositionService,
  ]
})
export class PositionModule { }
