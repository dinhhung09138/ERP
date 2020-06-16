import { NgModule } from '@angular/core';
import { ProfessionalQualificationComponent } from './professional-qualification.component';
import { Routes, RouterModule } from '@angular/router';
import { ProfessionalQualificationFormComponent } from './form/form.component';
import { ProfessionalQualificationService } from './professional-qualification.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ProfessionalQualificationComponent,
    data: { title: 'Professional Qualification' }
  }
]

@NgModule({
  declarations: [
    ProfessionalQualificationComponent,
    ProfessionalQualificationFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    ProfessionalQualificationService,
  ]
})
export class ProfessionalQualificationModule { }
