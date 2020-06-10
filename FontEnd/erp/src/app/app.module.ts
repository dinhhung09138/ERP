import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLoadModule } from './core/app-load.module';
import { HttpClientModule } from '@angular/common/http';
import { SessionContext } from './core/session.context';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { HeaderComponent } from './shared/components/header/header.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { MainMenuComponent } from './shared/components/main-menu/main-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainMenuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppLoadModule,
    BrowserAnimationsModule,
  ],
  providers: [
    HttpClientModule,
    SessionContext,
    AuthenticationGuard,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
