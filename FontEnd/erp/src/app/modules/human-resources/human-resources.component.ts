import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-human-resources',
  templateUrl: './human-resources.component.html',
  styleUrls: ['./human-resources.component.scss']
})
export class HumanResourcesComponent implements OnInit {

  linkSelected: string;

  constructor() { }

  ngOnInit(): void {
  }

  openSideMenu(link: string) {
    if (link === this.linkSelected) {
      this.linkSelected = '';
    } else {
      this.linkSelected = link;
    }
  }

}
