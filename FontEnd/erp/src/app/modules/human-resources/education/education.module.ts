import { NgModule } from '@angular/core';
import { EducationComponent } from './education.component';
import { Routes, RouterModule } from '@angular/router';
import { EducationFormComponent } from './form/form.component';
import { EducationService } from './education.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: EducationComponent,
    data: { title: 'Education' }
  }
]

@NgModule({
  declarations: [
    EducationComponent,
    EducationFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    EducationService,
  ]
})
export class EducationModule { }
