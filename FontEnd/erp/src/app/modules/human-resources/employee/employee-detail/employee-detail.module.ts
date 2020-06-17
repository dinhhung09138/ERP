import { NgModule } from "@angular/core";
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeDetailComponent } from './employee-detail.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: EmployeeDetailComponent,
  }
]

@NgModule({
  declarations: [
    EmployeeDetailComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  providers: []
})
export class EmployeeDetailModule { }
