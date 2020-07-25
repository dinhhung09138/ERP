import { PrecedenceDirective } from './../core/directives/precedence.directive';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NoDataAvailableComponent } from './components/no-data-available/no-data-available.component';
import { ElementLoadingComponent } from './components/element-loading/element-loading.component';
import { TableLoadingComponent } from './components/table-loading/table-loading.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FormatNumberPipe } from '../core/pipes/format-number.pipe';
import { FormatDecimalDirective } from '../core/directives/format-decimal.directive';
import { FormatCurrencyDirective } from '../core/directives/format-currency.directive';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';

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
    PrecedenceDirective,
    ConfirmDialogComponent,
  ],
  providers: [
    FormatNumberPipe,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
    PrecedenceDirective,
    ConfirmDialogComponent,
  ]
})
export class SharedModule { }
