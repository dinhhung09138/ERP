import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { TranslateService } from '@ngx-translate/core';

import { ApplicationConstant } from './../constants/app.constant';
import { ApplicationSettingViewModel } from '../models/app-setting.model';
import { UrlSettingViewModel } from '../models/url-setting.model';
import { APIUrlConstants } from '../constants/api-url.constant';

/**
 * A service used to read configuration setting before application initialize from setting files.
 */
@Injectable()
export class AppLoadService {

  private configPath = 'assets/configs/';

  constructor(
    private http: HttpClient,
    private translate: TranslateService) {
    }

  /**
   * Get server url config.
   */
  getUrlSetting() {
    return this.http.get<UrlSettingViewModel>(this.configPath + 'url.config.json').toPromise().then(response => {
      APIUrlConstants.authenticationApi = response.authenticationApi;
      APIUrlConstants.hrApi = response.hrApi;
      APIUrlConstants.commonApi = response.commonApi;
      APIUrlConstants.systemApi = response.systemApi;
    });
  }

  /**
   * Get application config
   */
  getApplicationConfig() {
    return this.http.get<ApplicationSettingViewModel>(this.configPath + 'application.config.json').toPromise().then(response => {
      ApplicationConstant.defaultLanguage = response.defaultLanguage;
      this.translate.use(ApplicationConstant.defaultLanguage);
      this.translate.get('SITE_TITLE').subscribe(message => {
        ApplicationConstant.siteTitle = ' | ' + message;
      });
    });
  }

}
