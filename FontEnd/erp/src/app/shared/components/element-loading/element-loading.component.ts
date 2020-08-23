import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';

@Component({
  selector: 'app-element-loading',
  templateUrl: './element-loading.component.html',
  styleUrls: ['./element-loading.component.css']
})
export class ElementLoadingComponent implements OnInit {

  @Input() Show = false;

  constructor(public translate: TranslateService) {
    translate.use(ApplicationConstant.defaultLanguage);
   }

  ngOnInit(): void {
  }

}
