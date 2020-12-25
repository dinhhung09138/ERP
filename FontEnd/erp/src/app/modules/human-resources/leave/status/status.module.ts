import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaveStatusComponent } from './status.component';
import { LeaveStatusFormComponent } from './form/form.component';



@NgModule({
  declarations: [
    LeaveStatusComponent,
    LeaveStatusFormComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LeaveStatusModule { }
