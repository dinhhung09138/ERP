import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-element-loading',
  templateUrl: './element-loading.component.html',
  styleUrls: ['./element-loading.component.css']
})
export class ElementLoadingComponent implements OnInit {

  @Input() Show = false;

  constructor() { }

  ngOnInit(): void {
  }

}
