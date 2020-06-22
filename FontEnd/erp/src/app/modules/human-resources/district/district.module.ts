import { NgModule } from '@angular/core';
import { DistrictComponent } from './district.component';
import { Routes, RouterModule } from '@angular/router';
import { DistrictFormComponent } from './form/form.component';
import { DistrictService } from './district.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

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
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    DistrictService,
  ]
})
export class DistrictModule { }
