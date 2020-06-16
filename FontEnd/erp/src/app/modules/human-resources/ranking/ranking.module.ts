import { NgModule } from '@angular/core';
import { RankingComponent } from './ranking.component';
import { Routes, RouterModule } from '@angular/router';
import { RankingFormComponent } from './form/form.component';
import { RankingService } from './ranking.service';
import { SharedModule } from 'src/app/shared/shared.module';

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
  ],
  providers: [
    RankingService,
  ]
})
export class RankingModule { }
