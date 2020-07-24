import { NgModule } from '@angular/core';
import { WardComponent } from './ward.component';
import { Routes, RouterModule } from '@angular/router';
import { WardFormComponent } from './form/form.component';
import { WardService } from './ward.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

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
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    WardService,
  ]
})
export class WardModule { }
