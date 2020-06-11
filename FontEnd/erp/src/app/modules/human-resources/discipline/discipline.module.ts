import { NgModule } from '@angular/core';
import { DisciplineComponent } from './discipline.component';
import { FormComponent } from './form/form.component';
import { Routes, RouterModule } from '@angular/router';
import { DisciplineService } from './discipline.service';
import { SharedModule } from 'src/app/shared/shared.module';

const routes: Routes = [
  {
    path: '',
    component: DisciplineComponent
  }
];


@NgModule({
  declarations: [
    DisciplineComponent,
    FormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
  ],
  providers: [
    DisciplineService,
  ]
})
export class DisciplineModule { }
