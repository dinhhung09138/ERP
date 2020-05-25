import { UserInfoModel } from './user-info.model';

export class TokenModel {
  accessToken: string;
  refreshToken: string;
  expiration: string;
  userInfo: UserInfoModel;
}
