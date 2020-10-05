import { Component, OnInit } from '@angular/core';

import { SessionContext } from '../../../core/session.context';
import { ModuleViewModel } from '../../../core/models/module.model';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent implements OnInit {

  listModule: ModuleViewModel[] = [];

  constructor(private context: SessionContext) { }

  ngOnInit(): void {
    const modules = this.context.getListModule();
    if (modules.length > 0) {
      this.listModule = modules;
    }
  }
}
