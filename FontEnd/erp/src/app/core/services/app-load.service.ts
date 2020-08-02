import { ApplicationConstant } from './../constants/app.constant';
import { ApplicationSettingInterface } from './../interfaces/app-setting.interface';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlSettingInterface } from '../interfaces/url-setting.interface';
import { APIUrlConstants } from '../constants/api-url.constant';

/**
 * A service used to read configuration setting before application initialize from setting files.
 */
@Injectable()
export class AppLoadService {

  private configPath = 'assets/configs/';

  constructor(private http: HttpClient) { }

  /**
   * Get server url config.
   */
  getUrlSetting(): Promise<any> {
    return this.http.get<UrlSettingInterface>(this.configPath + 'url.config.json').toPromise().then(response => {
      APIUrlConstants.authenticationApi = response.authenticationApi;
      APIUrlConstants.hrApi = response.hrApi;
      APIUrlConstants.marketingApi = response.marketingApi;
      return response;
    });
  }

  /**
   * Get application config
   */
  getApplicationConfig(): Promise<any> {
    return this.http.get<ApplicationSettingInterface>(this.configPath + 'application.config.json').toPromise().then(response => {
      ApplicationConstant.siteTitle = response.siteTitle;
      return response;
    });
  }

}
