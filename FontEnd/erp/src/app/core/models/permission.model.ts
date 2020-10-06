export class PermissionViewModel {
  allowView: boolean;
  allowInsert: boolean;
  allowUpdate: boolean;
  allowDelete: boolean;

  constructor() {
    this.allowView = false;
    this.allowInsert = false;
    this.allowUpdate = false;
    this.allowDelete = false;
  }
}
