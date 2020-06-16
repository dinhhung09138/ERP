import { NgModule } from '@angular/core';
import { ApproveStatusComponent } from './approve-status.component';
import { Routes, RouterModule } from '@angular/router';
import { ApproveStatusFormComponent } from './form/form.component';
import { ApproveStatusService } from './approve-status.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ApproveStatusComponent,
    data: { title: 'Approve Status' }
  }
]

@NgModule({
  declarations: [
    ApproveStatusComponent,
    ApproveStatusFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    ApproveStatusService,
  ]
})
export class ApproveStatusModule { }
