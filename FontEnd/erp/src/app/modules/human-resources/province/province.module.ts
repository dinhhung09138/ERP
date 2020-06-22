import { NgModule } from '@angular/core';
import { ProvinceComponent } from './province.component';
import { Routes, RouterModule } from '@angular/router';
import { ProvinceFormComponent } from './form/form.component';
import { ProvinceService } from './province.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';

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
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
  ],
  providers: [
    ProvinceService,
  ]
})
export class ProvinceModule { }
