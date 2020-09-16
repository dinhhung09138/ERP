import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import {MatMenuModule} from '@angular/material/menu';
import { MatPaginatorModule, MatPaginatorIntl } from '@angular/material/paginator';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';

import { ApiService } from './../core/services/api.service';
import { appInterceptors } from './app.interceptors';
import { PrecedenceDirective } from './../core/directives/precedence.directive';
import { NoDataAvailableComponent } from './components/no-data-available/no-data-available.component';
import { ElementLoadingComponent } from './components/element-loading/element-loading.component';
import { TableLoadingComponent } from './components/table-loading/table-loading.component';
import { FormatNumberPipe } from '../core/pipes/format-number.pipe';
import { FormatDecimalDirective } from '../core/directives/format-decimal.directive';
import { FormatCurrencyDirective } from '../core/directives/format-currency.directive';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { ErrorDialogComponent } from './components/error-dialog/error-dialog.component';
import { TablePaginatorComponent } from './components/table-paginator/table-paginator.component';
import { AppMatPaginatorIntl } from './services/mat-paginator-intl.service';
import { NotifyComponent } from './components/notify/notify.component';
import { HeaderComponent } from './components/header/header.component';
import { MainMenuComponent } from './components/main-menu/main-menu.component';
import { FooterComponent } from './components/footer/footer.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HttpLoaderFactory } from '../core/factories/http.loader.factory';
import { ApplicationConstant } from '../core/constants/app.constant';
import { FormatDatePipe } from '../core/pipes/format-date.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatPaginatorModule,
    MatMenuModule,
    RouterModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      }
    }),
  ],
  declarations: [
    // Components
    HeaderComponent,
    MainMenuComponent,
    FooterComponent,
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    TablePaginatorComponent,
    ConfirmDialogComponent,
    ErrorDialogComponent,
    NotifyComponent,
    PageNotFoundComponent,
    // Pipes
    FormatNumberPipe,
    FormatDatePipe,
    // Directives
    FormatDecimalDirective,
    FormatCurrencyDirective,
    PrecedenceDirective,
  ],
  providers: [
    // Directives
    // Use for change language of paginator.
    appInterceptors,
    {
      provide: MatPaginatorIntl,
      useClass: AppMatPaginatorIntl
    },
    // Services
    ApiService,
    TranslateService,
  ],
  exports: [
    // Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule,
    // Components
    HeaderComponent,
    MainMenuComponent,
    FooterComponent,
    NoDataAvailableComponent,
    ElementLoadingComponent,
    TableLoadingComponent,
    TablePaginatorComponent,
    ConfirmDialogComponent,
    MatPaginatorModule,
    PageNotFoundComponent,
    // Pipes
    FormatNumberPipe,
    FormatDatePipe,
    // Directives
    FormatDecimalDirective,
    FormatCurrencyDirective,
    PrecedenceDirective,
  ]
})
export class SharedModule {

  constructor(private translate: TranslateService) {
    if (ApplicationConstant.defaultLanguage) {
      translate.use(ApplicationConstant.defaultLanguage);
    }
  }
 }
