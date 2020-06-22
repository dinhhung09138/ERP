import { NgModule, APP_INITIALIZER } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { AppLoadService } from './services/app-load.service';

/**
 * Load all config data before application initialize.
 */
@NgModule({
  imports: [
    HttpClientModule
  ],
  providers: [
    AppLoadService,
    { provide: APP_INITIALIZER, useFactory: (config: AppLoadService) => () => config.getUrlSetting(), deps: [AppLoadService], multi: true }
  ],
  declarations: []
})

export class AppLoadModule { }
