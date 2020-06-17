import { NgModule } from "@angular/core";
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeInfoComponent } from './employee-info.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: EmployeeInfoComponent,
  }
]

@NgModule({
  declarations: [
    EmployeeInfoComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  providers: []
})
export class EmployeeInfoModule { }
