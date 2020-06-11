import { NgModule } from '@angular/core';
import { CommendationComponent } from './commendation.component';
import { Routes, RouterModule } from '@angular/router';
import { CommendationFormComponent } from './form/form.component';
import { CommendationService } from './commendation.service';
import { FormatNumberPipe } from 'src/app/core/pipes/format-number.pipe';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: CommendationComponent,
    data: { title: 'Commendation' }
  }
]

@NgModule({
  declarations: [
    CommendationComponent,
    CommendationFormComponent,
    FormatNumberPipe,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    CommendationService,
  ]
})
export class CommendationModule { }
