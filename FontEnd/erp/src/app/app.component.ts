import { ApplicationConstant } from './core/constants/app.constant';
import { LoadingService } from './core/services/loading.service';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterEvent, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { map, catchError, filter } from 'rxjs/operators';
import { Observable, of, pipe } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ERP';

  constructor(
    private router: Router,
    private titleService: Title,
    private activatedRoute: ActivatedRoute,
    private loadingService: LoadingService) {
      this.router.events.subscribe((e: RouterEvent) => {
        this.navigationInterceptor(e);
      });
  }

  ngOnInit() {
    this.showTitle(this.router);
  }

  navigationInterceptor(event: RouterEvent): void {
    if (event instanceof NavigationStart) {
      this.loadingService.setNavigationStatus(true);
    }
    if (event instanceof NavigationEnd || event instanceof NavigationError || event instanceof NavigationCancel) {
      this.loadingService.setNavigationStatus(false);
      window.scroll(0, 0);
    }
  }

  showTitle(router: Router) {
    router.events.pipe(
      filter(event => event instanceof NavigationEnd),
    )
    .subscribe(() => {
      const routeObject = this.getChild(this.activatedRoute);
      routeObject.data.subscribe(data => {
        this.titleService.setTitle((data.title || '') + ' | ' + ApplicationConstant.siteTitle);
      });
    });
  }

  getChild(activatedRoute: ActivatedRoute) {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }

}
