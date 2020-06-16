import { NgModule } from '@angular/core';
import { DisciplineComponent } from './discipline.component';
import { Routes, RouterModule } from '@angular/router';
import { DisciplineFormComponent } from './form/form.component';
import { DisciplineService } from './discipline.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: DisciplineComponent,
    data: { title: 'Discipline' }
  }
]

@NgModule({
  declarations: [
    DisciplineComponent,
    DisciplineFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    DisciplineService,
  ]
})
export class DisciplineModule { }
