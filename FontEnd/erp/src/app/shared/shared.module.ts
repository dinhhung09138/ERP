import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { NoDataAvailableComponent } from './components/no-data-available/no-data-available.component';
import { ElementLoadingComponent } from './components/element-loading/element-loading.component';
import { TableLoadingComponent } from './components/table-loading/table-loading.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FormatNumberPipe } from '../core/pipes/format-number.pipe';
import { FormatDecimalDirective } from '../core/directives/format-decimal.directive';
import { FormatCurrencyDirective } from '../core/directives/format-currency.directive';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
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
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
  ]
})
export class SharedModule { }
