import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppraiseComponent } from './appraise.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: AppraiseComponent,
  }
];

@NgModule({
  declarations: [
    AppraiseComponent
  ],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class AppraiseModule { }
