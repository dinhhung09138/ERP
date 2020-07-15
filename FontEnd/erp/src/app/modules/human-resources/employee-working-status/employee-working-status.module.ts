import { NgModule } from '@angular/core';
import { EmployeeWorkingStatusComponent } from './employee-working-status.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { EmployeeWorkingStatusService } from './employee-working-status.service';
import { EmployeeWorkingStatusFormComponent } from './form/form.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeWorkingStatusComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [
    EmployeeWorkingStatusComponent,
    EmployeeWorkingStatusFormComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    EmployeeWorkingStatusService,
  ]
})
export class EmployeeWorkingStatusModule { }
