import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaveTypeComponent } from './type.component';
import { LeaveTypeFormComponent } from './form/form.component';



@NgModule({
  declarations: [
    LeaveTypeComponent,
    LeaveTypeFormComponent
  ],
  imports: [
    CommonModule
  ]
})
export class LeaveTypeModule { }
