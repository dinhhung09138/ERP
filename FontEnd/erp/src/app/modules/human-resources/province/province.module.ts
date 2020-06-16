import { NgModule } from '@angular/core';
import { ProvinceComponent } from './province.component';
import { Routes, RouterModule } from '@angular/router';
import { ProvinceFormComponent } from './form/form.component';
import { ProvinceService } from './province.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ProvinceComponent,
    data: { title: 'Province' }
  }
]

@NgModule({
  declarations: [
    ProvinceComponent,
    ProvinceFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    ProvinceService,
  ]
})
export class ProvinceModule { }
