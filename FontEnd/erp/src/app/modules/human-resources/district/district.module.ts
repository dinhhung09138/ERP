import { NgModule } from '@angular/core';
import { DistrictComponent } from './district.component';
import { Routes, RouterModule } from '@angular/router';
import { DistrictFormComponent } from './form/form.component';
import { DistrictService } from './district.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';

const route: Routes = [
  {
    path: '',
    component: DistrictComponent,
    data: { title: 'District' }
  }
]

@NgModule({
  declarations: [
    DistrictComponent,
    DistrictFormComponent,
  ],
  imports: [
    SharedModule,
    NgSelectModule,
    RouterModule.forChild(route),
  ],
  providers: [
    DistrictService,
  ]
})
export class DistrictModule { }
