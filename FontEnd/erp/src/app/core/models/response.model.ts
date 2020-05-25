import { ResponseStatus } from '../enums/response-status.enum';

export class ResponseModel {
  responseStatus: ResponseStatus;
  errors: any[];
  result: any;
  extra: any[];
}
