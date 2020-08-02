import { NgModule } from '@angular/core';
import { RankingComponent } from './ranking.component';
import { Routes, RouterModule } from '@angular/router';
import { RankingFormComponent } from './form/form.component';
import { RankingService } from './ranking.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: RankingComponent,
    data: { title: 'Xếp hạng học tập' }
  }
];

@NgModule({
  declarations: [
    RankingComponent,
    RankingFormComponent,
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
    RankingService,
  ]
})
export class RankingModule { }
