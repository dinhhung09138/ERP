import { HttpErrorStatusEnum } from './../enums/http-error.enum';

export interface DialogDataInterface {
  animal: string;
  title: string;
  message: string;
  isError: boolean;
  httpError: HttpErrorStatusEnum;
  isPopup: boolean;
  itemId: number;
  employeeId: number;
  data: any[];
}
