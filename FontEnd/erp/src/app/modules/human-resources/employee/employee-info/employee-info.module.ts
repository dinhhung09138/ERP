import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeeInfoComponent } from './employee-info.component';
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
import { EmployeeService } from '../employee.service';
import { DatetimePipe } from 'src/app/core/pipes/datetime.pipe';
import { NgSelectModule } from '@ng-select/ng-select';
import { EmployeeInformationComponent } from './information/information.component';

const routes: Routes = [
  {
    path: '',
    component: EmployeeInfoComponent,
  }
];

@NgModule({
  declarations: [
    EmployeeInfoComponent,
    EmployeeInformationComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    NgSelectModule,
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
    EmployeeService,
    DatetimePipe,
  ]
})
export class EmployeeInfoModule { }
