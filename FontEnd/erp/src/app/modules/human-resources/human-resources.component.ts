import { Component, OnInit } from '@angular/core';

import { SessionContext } from '../../core/session.context';
import { FunctionViewModel } from '../../core/models/function.model';

@Component({
  selector: 'app-human-resources',
  templateUrl: './human-resources.component.html',
  styleUrls: ['./human-resources.component.scss']
})
export class HumanResourcesComponent implements OnInit {

  moduleCode = 'HR';
  linkSelected: string;
  sidebar: FunctionViewModel[] = [];

  constructor(private context: SessionContext) { }

  ngOnInit(): void {
    const funcs = this.context.getSidebarByModule(this.moduleCode);

    if (funcs.length > 0) {
      this.sidebar = funcs;
    }
  }

  openSideMenu(link: string) {
    if (link === this.linkSelected) {
      this.linkSelected = '';
    } else {
      this.linkSelected = link;
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
