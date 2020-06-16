import { NgModule } from '@angular/core';
import { IdentificationTypeComponent } from './identification-type.component';
import { Routes, RouterModule } from '@angular/router';
import { IdentificationTypeFormComponent } from './form/form.component';
import { IdentificationTypeService } from './identification-type.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: IdentificationTypeComponent,
    data: { title: 'Identification Type' }
  }
]

@NgModule({
  declarations: [
    IdentificationTypeComponent,
    IdentificationTypeFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    IdentificationTypeService,
  ]
})
export class IdentificationTypeModule { }
