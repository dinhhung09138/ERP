import { RoleViewModel } from './../../role/role.model';
import { ResponseModel } from './../../../../core/models/response.model';
import { AccountService } from './../account.service';
import { ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormGroupDirective, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-system-account-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class AccountFormComponent implements OnInit {

  @ViewChild(FormGroupDirective, {static: true}) formDirective: FormGroupDirective;
  @Output() reloadTableEvent = new EventEmitter<boolean>();

  listRole: RoleViewModel[] = [];

  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private accountService: AccountService
  ) {
  }

  ngOnInit(): void {
    this.activatedRoute.data.subscribe(response => {
      this.listRole = response.data.role.result;
      console.log(this.listRole);
    });
  }

  onCreateClick() {

  }

  onUpdateClick(id: number) {

  }

  onCloseClick() {

  }
}
