import { NgModule } from '@angular/core';
import { ProvinceComponent } from './province.component';
import { Routes, RouterModule } from '@angular/router';
import { ProvinceFormComponent } from './form/form.component';
import { ProvinceService } from './province.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: ProvinceComponent,
    data: { title: 'Province' }
  }
];

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
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    ProvinceService,
  ]
})
export class ProvinceModule { }
