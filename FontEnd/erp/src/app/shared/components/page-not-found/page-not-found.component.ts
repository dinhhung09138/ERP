import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.css']
})
export class PageNotFoundComponent implements OnInit {

  constructor(public translate: TranslateService) {
    translate.use(ApplicationConstant.defaultLanguage);
  }

  ngOnInit(): void {
  }

}
