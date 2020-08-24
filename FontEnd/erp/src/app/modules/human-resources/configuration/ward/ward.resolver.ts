import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';
import { ProvinceService } from '../province/province.service';
import { DistrictService } from '../district/district.service';

@Injectable()
export class WardResolver implements Resolve<Observable<any>> {

  constructor(
    private provinceService: ProvinceService,
    private districtService: DistrictService) { }

  resolve() {

    return forkJoin([
      this.provinceService.getDropdown(),
      this.districtService.getDropdown(),
    ]).pipe(
      map(
        ([first, second]) => {
          return {
            provinces: first,
            districts: second,
          };
        }));
  }
}
