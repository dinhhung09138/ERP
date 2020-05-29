export class BaseViewModel {
  id: number;
  isActive: boolean;
  createDate: Date;
  createBy: number;
  updateDate: Date;
  updateBy: number;

  constructor() {
    this.isActive = true;
    this.createDate = new Date();
    this.updateDate = new Date();
  }
}
