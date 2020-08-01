import { appInterceptors } from './app.interceptors';
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
import { ErrorDialogComponent } from './components/error-dialog/error-dialog.component';
import { TablePaginatorComponent } from './components/table-paginator/table-paginator.component';
import { MatPaginatorModule, MatPaginatorIntl } from '@angular/material/paginator';
import { AppMatPaginatorIntl } from './services/mat-paginator-intl.service';
import { NotifyComponent } from './components/notify/notify.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatPaginatorModule,
  ],
  declarations: [
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    TablePaginatorComponent,
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
    PrecedenceDirective,
    ConfirmDialogComponent,
    ErrorDialogComponent,
    NotifyComponent,
  ],
  providers: [
    FormatNumberPipe,
    // Use for change language of paginator.
    appInterceptors,
    {
      provide: MatPaginatorIntl,
      useClass: AppMatPaginatorIntl
    },
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    TablePaginatorComponent,
    FormatNumberPipe,
    FormatDecimalDirective,
    FormatCurrencyDirective,
    PrecedenceDirective,
    ConfirmDialogComponent,
    MatPaginatorModule,
  ]
})
export class SharedModule { }
