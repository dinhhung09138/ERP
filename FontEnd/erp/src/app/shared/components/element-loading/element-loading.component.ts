import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-element-loading',
  templateUrl: './element-loading.component.html',
  styleUrls: ['./element-loading.component.scss']
})
export class ElementLoadingComponent implements OnInit {

  @Input() show = false;

  constructor() {
   }

  ngOnInit(): void {
  }

}
