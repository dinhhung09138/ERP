import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

import { Observable } from 'rxjs';

import { ProvinceService } from '../province/province.service';
import { ResponseModel } from 'src/app/core/models/response.model';

@Injectable()
export class DistrictResolver implements Resolve<Observable<ResponseModel>> {

  constructor(private provinceService: ProvinceService) { }

  resolve() {
    return this.provinceService.getDropdown();
  }
}
