import { Component, OnInit, Input } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ApplicationConstant } from '../../../core/constants/app.constant';

@Component({
  selector: 'app-no-data-available',
  templateUrl: './no-data-available.component.html',
  styleUrls: ['./no-data-available.component.css']
})
export class NoDataAvailableComponent implements OnInit {

  @Input() Show = false;

  constructor(public translate: TranslateService) {
    translate.use(ApplicationConstant.defaultLanguage);
  }

  ngOnInit(): void {
  }

}
