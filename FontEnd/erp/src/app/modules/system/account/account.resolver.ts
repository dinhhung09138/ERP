import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { RoleService } from './../role/role.service';

@Injectable()
export class AccountResolver implements Resolve<Observable<any>> {

  constructor(
    private roleService: RoleService
  ) {}

  resolve() {
    return forkJoin([
      this.roleService.getDropdown()
    ]).pipe(
      map(([roleData]) => {
        return {
          role: roleData
        };
      })
    );
  }
}
