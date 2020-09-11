import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { EmployeeWorkingStatusComponent } from './employee-working-status.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeWorkingStatusService } from './employee-working-status.service';
import { EmployeeWorkingStatusFormComponent } from './form/form.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeWorkingStatusComponent,
    pathMatch: 'full',
    data: { title: 'SCREEN.HR.CONFIGURATION.WORKING_STATUS.TITLE' }
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
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    EmployeeWorkingStatusService,
  ]
})
export class EmployeeWorkingStatusModule { }
