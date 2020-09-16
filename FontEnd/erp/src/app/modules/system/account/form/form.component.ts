import { Component, Input, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-system-account-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class AccountFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, {static: true}) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit(): void {
  }

  onCreateClick() {

  }

  onUpdateClick(id: number) {

  }

  onCloseClick() {

  }
}
