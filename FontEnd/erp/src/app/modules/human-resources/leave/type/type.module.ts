import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';


import { LeaveTypeService } from './type.service';
import { SharedModule } from '../../../../shared/shared.module';
import { LeaveTypeComponent } from './type.component';
import { LeaveTypeFormComponent } from './form/form.component';

const route: Routes = [
  {
    path: '',
    component: LeaveTypeComponent,
    data: { title: 'SCREEN.HR.LEAVE_MANAGEMENT.LEAVE_TYPE.TITLE' }
  }
]


@NgModule({
  declarations: [
    LeaveTypeComponent,
    LeaveTypeFormComponent
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
    LeaveTypeService
  ]
})
export class LeaveTypeModule { }
