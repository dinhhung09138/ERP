import { NgModule } from "@angular/core";
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeInfoComponent } from './employee-info.component';
import { Routes, RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

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
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: []
})
export class EmployeeInfoModule { }
