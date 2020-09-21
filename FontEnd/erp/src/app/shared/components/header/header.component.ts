import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SessionContext } from '../../../core/session.context';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(
    private router: Router,
    private context: SessionContext) { }

  ngOnInit(): void {
  }

  onLogoutClick() {
    this.context.clearToken();
    this.router.navigate(['/login']);
  }

}
