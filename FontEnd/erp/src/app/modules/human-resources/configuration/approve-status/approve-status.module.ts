import { NgModule } from '@angular/core';
import { ApproveStatusComponent } from './approve-status.component';
import { Routes, RouterModule } from '@angular/router';
import { ApproveStatusFormComponent } from './form/form.component';
import { ApproveStatusService } from './approve-status.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: ApproveStatusComponent,
    data: { title: 'Trạng thái phê duyệt' }
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
