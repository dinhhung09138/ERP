import { LoadingService } from './core/services/loading.service';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterEvent } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ERP';

  constructor(
    private router: Router,
    private loadingService: LoadingService) {
      this.router.events.subscribe((e: RouterEvent) => {
        this.navigationInterceptor(e);
      });
  }

  navigationInterceptor(event: RouterEvent): void {
    if (event instanceof NavigationStart) {
      window.scroll(0, 0);
      this.loadingService.setNavigationStatus(true);
    }
    if (event instanceof NavigationEnd || event instanceof NavigationError || event instanceof NavigationCancel) {
      this.loadingService.setNavigationStatus(false);
    }
  }
}
