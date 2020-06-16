import { NgModule } from '@angular/core';
import { WardComponent } from './ward.component';
import { Routes, RouterModule } from '@angular/router';
import { WardFormComponent } from './form/form.component';
import { WardService } from './ward.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';

const route: Routes = [
  {
    path: '',
    component: WardComponent,
    data: { title: 'Ward' }
  }
]

@NgModule({
  declarations: [
    WardComponent,
    WardFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    NgSelectModule,
  ],
  providers: [
    WardService,
  ]
})
export class WardModule { }
