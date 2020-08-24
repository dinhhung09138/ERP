import { NgModule } from '@angular/core';
import { AccountComponent } from './account.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path:'',
    component:AccountComponent
  }
]

@NgModule({
  declarations: [AccountComponent],
  imports: [
    RouterModule.forChild(routes)
  ]
})
export class AccountModule { }
