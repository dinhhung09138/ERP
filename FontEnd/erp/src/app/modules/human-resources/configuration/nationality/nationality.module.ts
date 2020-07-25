import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NationalityComponent } from './nationality.component';
import { FormComponent } from './form/form.component';



@NgModule({
  declarations: [NationalityComponent, FormComponent],
  imports: [
    CommonModule
  ]
})
export class NationalityModule { }
