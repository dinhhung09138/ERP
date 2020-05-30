import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UrlSettingInterface } from '../interfaces/url-setting.interface';
import { ApiUrlModel } from '../models/api-url.model';

/**
 * A service used to read configuration setting before application initialize from setting files.
 */
@Injectable()
export class AppLoadService {

  private configPath = 'assets/configs/';

  constructor(private http: HttpClient) {}

  /**
   * Get server url config.
   */
  getUrlSetting(): Promise<any> {
    return this.http.get<UrlSettingInterface>(this.configPath + 'url.config.json').toPromise().then(response => {
      ApiUrlModel.authenticationApi = response.authenticationApi;
      ApiUrlModel.gymApi = response.gymApi;
      ApiUrlModel.marketingApi = response.marketingApi;
      console.log(response);
      return response;
    });
  }

  /**
   * Get server url config.
   */
  getUrlSetting1(): Promise<any> {
    return this.http.get<UrlSettingInterface>(this.configPath + 'url.config.json').toPromise().then(response => {
      console.log(response);
      return response;
    });
  }
}