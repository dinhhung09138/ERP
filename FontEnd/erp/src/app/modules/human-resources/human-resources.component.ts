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
      console.log(funcs);
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
    const fc = this.sidebar.find(m => m.code === code);

    if (parentCode.length === 0 && this.sidebar.some(m => m.parentCode === code)) {
      return 1;
    }

    if (fc.commands.length === 0 || fc.commands.some(c => c.isView === true)) {
      return -1;
    }

    return 0;
  }

}
