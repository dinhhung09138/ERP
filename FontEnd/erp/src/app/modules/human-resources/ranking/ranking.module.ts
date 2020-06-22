import { NgModule } from '@angular/core';
import { RankingComponent } from './ranking.component';
import { Routes, RouterModule } from '@angular/router';
import { RankingFormComponent } from './form/form.component';
import { RankingService } from './ranking.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

const route: Routes = [
  {
    path: '',
    component: RankingComponent,
    data: { title: 'Ranking' }
  }
]

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
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    RankingService,
  ]
})
export class RankingModule { }
