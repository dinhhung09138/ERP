import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpecializeComponent } from './specialize.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: SpecializeComponent,
  }
];

@NgModule({
  declarations: [
    SpecializeComponent
  ],
  imports: [
    RouterModule.forChild(routes),
  ]
})
export class SpecializeModule { }
