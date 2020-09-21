import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SessionContext } from '../../../core/session.context';
import { UserInfoModel } from '../../../core/models/user-info.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  userInfo: UserInfoModel;

  constructor(
    private router: Router,
    private context: SessionContext) { }

  ngOnInit(): void {
    this.userInfo = this.context.getUser();
  }

  onLogoutClick() {
    this.context.clearToken();
    this.router.navigate(['/login']);
  }

  getAvatar() {
    if (this.userInfo && this.userInfo.avatar) {
      return this.userInfo.avatar;
    }
    return '../../../../assets/images/no-image.png';
  }

}
