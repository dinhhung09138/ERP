import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';

import { SharedModule } from '../../../../shared/shared.module';
import { LeaveStatusComponent } from './status.component';
import { LeaveStatusFormComponent } from './form/form.component';
import { LeaveStatusService } from './status.service';

const route: Routes = [
  {
    path: '',
    component: LeaveStatusComponent,
    data: { title: 'SCREEN.HR.LEAVE_MANAGEMENT.LEAVE_TYPE.TITLE' }
  }
]

@NgModule({
  declarations: [
    LeaveStatusComponent,
    LeaveStatusFormComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule
  ],
  providers: [
    LeaveStatusService
  ]
})
export class LeaveStatusModule { }
