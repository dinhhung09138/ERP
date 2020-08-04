import { AuthenticationService } from './services/authentication.service';
import { LoadingService } from './services/loading.service';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NotifyService } from './services/notify.service';
import { DialogService } from './services/dialog.service';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppLoadService } from './services/app-load.service';


/**
 * Load all config data before application initialize.
 */
@NgModule({
  imports: [
    HttpClientModule,
    MatSnackBarModule,
    MatDialogModule,
  ],
  providers: [
    AppLoadService,
    DialogService,
    NotifyService,
    LoadingService,
    AuthenticationService,
    {
      provide: APP_INITIALIZER,
      useFactory: (config: AppLoadService) => () => config.getUrlSetting(),
      deps: [AppLoadService],
      multi: true
    },
    {
      provide: APP_INITIALIZER,
      useFactory: (config: AppLoadService) => () => config.getApplicationConfig(),
      deps: [AppLoadService],
      multi: true
    },
    {
      provide: APP_INITIALIZER,
      useFactory: (authenticationService: AuthenticationService) => () => authenticationService.refreshToken(),
      deps: [AuthenticationService],
      multi: true,
    }
  ],
  declarations: []
})

export class AppLoadModule { }
