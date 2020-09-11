import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { ApproveStatusComponent } from './approve-status.component';
import { ApproveStatusFormComponent } from './form/form.component';
import { ApproveStatusService } from './approve-status.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ApproveStatusComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.APPROVE_STATUS.TITLE' }
  }
];

@NgModule({
  declarations: [
    ApproveStatusComponent,
    ApproveStatusFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    ApproveStatusService,
  ]
})
export class ApproveStatusModule { }
