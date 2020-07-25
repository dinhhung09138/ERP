import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReligionComponent } from './religion.component';
import { FormComponent } from './form/form.component';



@NgModule({
  declarations: [ReligionComponent, FormComponent],
  imports: [
    CommonModule
  ]
})
export class ReligionModule { }
