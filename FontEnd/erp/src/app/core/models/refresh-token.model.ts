export class RefreshTokenModel {
  userId: number;
  token: string;

  constructor() {
    this.userId = 0;
    this.token = '';
  }
}
