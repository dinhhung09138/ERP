import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';

import { Observable, forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';

import { EmployeeWorkingStatusService } from '../../configuration/employee-working-status/employee-working-status.service';
import { PositionService } from '../../position/position.service';

@Injectable()
export class EmployeeInfoResolver implements Resolve<Observable<any>> {

    constructor(
        private workingStatusService: EmployeeWorkingStatusService,
        private positionService: PositionService
    ) { }

    resolve() {
        return forkJoin([
            this.workingStatusService.getDropdown(),
            this.positionService.getDropdown(),
        ]).pipe(
            map(
                ([workingStatus, position]) => {
                    return {
                      listWorkingStatus: workingStatus,
                      listPosition: position
                    };
            }));
    }
}
