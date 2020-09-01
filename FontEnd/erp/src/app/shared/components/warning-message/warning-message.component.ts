import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-warning-message',
  templateUrl: './warning-message.component.html',
  styleUrls: ['./warning-message.component.scss']
})
export class WarningMessageComponent implements OnInit {

  @Input() listMeg: any[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
