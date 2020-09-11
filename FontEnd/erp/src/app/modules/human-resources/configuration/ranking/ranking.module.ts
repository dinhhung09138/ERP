import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { RankingComponent } from './ranking.component';
import { RankingFormComponent } from './form/form.component';
import { RankingService } from './ranking.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: RankingComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.RANKING.TITLE' }
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
