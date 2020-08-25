import { NgModule } from '@angular/core';
import { CommendationComponent } from './commendation.component';
import { Routes, RouterModule } from '@angular/router';
import { CommendationFormComponent } from './form/form.component';
import { CommendationService } from './commendation.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';

const route: Routes = [
  {
    path: '',
    component: CommendationComponent,
    data: { title: 'SCREEN.HR.COMMENDATION.TITLE' }
  }
];

@NgModule({
  declarations: [
    CommendationComponent,
    CommendationFormComponent,
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
    CommendationService,
  ]
})
export class CommendationModule { }
