import { Injectable } from "@angular/core";
import { Resolve } from '@angular/router';
import { Observable, forkJoin } from 'rxjs';
import { ResponseModel } from 'src/app/core/models/response.model';
import { EmployeeWorkingStatusService } from '../../employee-working-status/employee-working-status.service';
import { map } from 'rxjs/operators';

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
