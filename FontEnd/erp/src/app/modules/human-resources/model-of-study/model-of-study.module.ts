import { NgModule } from '@angular/core';
import { ModelOfStudyComponent } from './model-of-study.component';
import { Routes, RouterModule } from '@angular/router';
import { ModelOfStudyFormComponent } from './form/form.component';
import { ModelOfStudyService } from './model-of-study.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ModelOfStudyComponent,
    data: { title: 'Model Of Study' }
  }
]

@NgModule({
  declarations: [
    ModelOfStudyComponent,
    ModelOfStudyFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    ModelOfStudyService,
  ]
})
export class ModelOfStudyModule { }
