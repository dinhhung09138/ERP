import { Component, OnInit } from '@angular/core';

import { SessionContext } from './../../core/session.context';
import { FunctionViewModel } from './../../core/models/function.model';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html',
  styleUrls: ['./system.component.scss']
})
export class SystemComponent implements OnInit {

  moduleCode = 'SYSTEM';
  sidebar: FunctionViewModel[] = [];

  constructor(private context: SessionContext) { }

  ngOnInit(): void {
    const funcs = this.context.getSidebarByModule(this.moduleCode);

    if (funcs.length > 0) {
      this.sidebar = funcs;
    }
  }

  checkSubMenu(code: string, parentCode: string): number {
    // Return if item in sub-menu
    if (parentCode.length > 0) {
      return -1;
    }

    const fc = this.sidebar.find(m => m.code === code);

    // Return if have some sub-menu items
    if (this.sidebar.some(m => m.parentCode === code)) {
      return 1;
    }
    // Return if item no command or no view status = true
    if (fc.commands.length === 0 || !fc.commands.some(c => c.isView === true)) {
      return -1;
    }
    // Return if item is a single menu
    return 0;
  }

  getListSubMenu(code: string): FunctionViewModel[] {
    const listFunc = this.sidebar.filter(m => m.parentCode === code && m.commands.some(c => c.isView === true));
    return listFunc;
  }

}
