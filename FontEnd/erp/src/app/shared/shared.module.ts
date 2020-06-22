import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { NoDataAvailableComponent } from './components/no-data-available/no-data-available.component';
import { ElementLoadingComponent } from './components/element-loading/element-loading.component';
import { TableLoadingComponent } from './components/table-loading/table-loading.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatTabsModule } from '@angular/material/tabs';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { FormatNumberPipe } from '../core/pipes/format-number.pipe';
import { FormatDecimalDirective } from '../core/directives/format-decimal.directive';
import { FormatCurrencyDirective } from '../core/directives/format-currency.directive';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
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
  declarations: [
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
  ],
  providers: [
    FormatNumberPipe,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatTabsModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
  ]
})
export class SharedModule { }
