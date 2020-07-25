import { HttpErrorStatusEnum } from './../enums/http-error.enum';
export interface DialogDataInterface {
  animal: string;
  title: string;
  isError: boolean;
  httpError: HttpErrorStatusEnum;
}
