import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-table-loading',
  templateUrl: './table-loading.component.html',
  styleUrls: ['./table-loading.component.css']
})
export class TableLoadingComponent implements OnInit {

  @Input() Show = false;
  constructor() { }

  ngOnInit(): void {
  }

}