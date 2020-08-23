import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';

@Component({
  selector: 'app-table-loading',
  templateUrl: './table-loading.component.html',
  styleUrls: ['./table-loading.component.css']
})
export class TableLoadingComponent implements OnInit {

  @Input() Show = false;
  constructor(public translate: TranslateService) {
    translate.use(ApplicationConstant.defaultLanguage);
  }

  ngOnInit(): void {
  }

}
