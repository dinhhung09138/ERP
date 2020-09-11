import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { EmployeeWorkingStatusService } from '../../configuration/employee-working-status/employee-working-status.service';

@Injectable()
export class EmployeeInfoResolver implements Resolve<Observable<any>> {

    constructor(
        private workingStatusService: EmployeeWorkingStatusService
    ) { }

    resolve() {
        return forkJoin([
            this.workingStatusService.getDropdown()
        ]).pipe(
            map(
                ([first]) => {
                    return {
                        workingStatusList: first
                    };
            }));
    }
}
