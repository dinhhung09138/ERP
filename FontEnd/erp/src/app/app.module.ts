import { SpinnerComponent } from './shared/components/spinner/spinner.component';
import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLoadModule } from './core/app-load.module';
import { SessionContext } from './core/session.context';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { SharedModule } from './shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppLoadModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule,
    SharedModule,
  ],
  providers: [
    Title,
    HttpClientModule,
    SessionContext,
    AuthenticationGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
