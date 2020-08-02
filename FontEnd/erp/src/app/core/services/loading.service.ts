import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable()
export class LoadingService {

  private isNavigate = new BehaviorSubject(false);

  shareIsNavigationStatus = this.isNavigate.asObservable();

  constructor() { }

  setNavigationStatus(status: boolean) {
    this.isNavigate.next(status);
  }
}
