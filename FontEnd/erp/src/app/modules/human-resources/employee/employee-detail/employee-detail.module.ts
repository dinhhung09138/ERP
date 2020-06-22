import { NgModule } from "@angular/core";
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeDetailComponent } from './employee-detail.component';
import { Routes, RouterModule } from '@angular/router';
import { AppDateAdapter } from 'src/app/core/helpers/format-datepicker.helper';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTabsModule } from '@angular/material/tabs';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';

const routes: Routes = [
  {
    path: '',
    component: EmployeeDetailComponent,
  }
]

@NgModule({
  declarations: [
    EmployeeDetailComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatIconModule,
  ],
  providers: [
    AppDateAdapter,
  ]
})
export class EmployeeDetailModule { }
