import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { RoleService } from './../role/role.service';
import { EmployeeService } from '../../human-resources/employee/employee.service';

@Injectable()
export class AccountResolver implements Resolve<Observable<any>> {

  constructor(
    private roleService: RoleService,
    private employeeService: EmployeeService,
  ) {}

  resolve() {
    return forkJoin([
      this.roleService.getDropdown(),
      this.employeeService.getEmployeeDontHaveAccount(),
    ]).pipe(
      map(([roleData, employeeData]) => {
        return {
          role: roleData,
          employees: employeeData,
        };
      })
    );
  }
}
