import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router, RouterEvent, ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

import { filter } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';

import { ApplicationConstant } from './core/constants/app.constant';
import { LoadingService } from './core/services/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(
    private translate: TranslateService,
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
        this.translate.get(data.title).subscribe(message => {
          this.titleService.setTitle(message + ApplicationConstant.siteTitle);
        });
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
