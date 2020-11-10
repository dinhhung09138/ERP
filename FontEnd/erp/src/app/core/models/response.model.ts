import { ResponseStatus } from '../enums/response-status.enum';

/**
 * Get the response object from api return. *
 */
export class ResponseModel {
  responseStatus: ResponseStatus;
  errors: any[];
  result: any;
  extra: any[];
}
