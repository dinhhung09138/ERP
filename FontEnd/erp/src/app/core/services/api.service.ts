import { NotifyService } from './notify.service';
import { FilterModel } from './../models/filter-table.model';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ResponseModel } from './../models/response.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseStatus } from '../enums/response-status.enum';

/**
 * This service use for make some common call to Api for getting data.
 * There are 4 type of common function
 * 1. getList(): Get list of data to show on the table.
 * 2. getDropdown(): Get list of data to show on the dropdown selection.
 * 3. item(): Get data of item detail by id.
 * 4. save(): Save data.
 */
@Injectable()
export class ApiService {

  constructor(
    private http: HttpClient,
    private notifyService: NotifyService) { }

  /**
   * Get list of data to show on the table.
   * @param url: string.
   * @param filter: Filter object model.
   */
  getListDataByFilterModel(url: string, filter: FilterModel): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(url, filter).pipe(
      map((data: ResponseModel) => {
        return data;
      })
    );
  }

  /**
   * Get list data to show on dropdown selection
   * @param url: string
   */
  getListData(url: string): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(url).pipe(
      map((data: ResponseModel) => {
        return data;
      })
    );
  }

  /**
   * Get data by Id,
   * url format: ---?id={id},
   * @param url: string
   * @param id: Id: number
   */
  getDataById(url: string, id: number): Observable<ResponseModel> {
    return this.http.get<ResponseModel>(url + '?id=' + id).pipe(
      map((data: ResponseModel) => {
        return data;
      })
    );
  }

  insert(url: string, model: any): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(url, model).pipe(
      map((data: ResponseModel) => {
        if (data.responseStatus === ResponseStatus.success) {
          this.notifyService.notifyInsert(true);
        }
        return data;
      })
    );
  }

  update(url: string, model: any): Observable<ResponseModel> {
    return this.http.put<ResponseModel>(url, model).pipe(
      map((data: ResponseModel) => {
        if (data.responseStatus === ResponseStatus.success) {
          this.notifyService.notifyUpdate(true);
        }
        return data;
      })
    );
  }

  updateFormData(url: string, model: FormData): Observable<ResponseModel> {
    return this.http.post<ResponseModel>(url, model).pipe(
      map((data: ResponseModel) => {
        if (data.responseStatus === ResponseStatus.success) {
          this.notifyService.notifyUpdate(true);
        }
        return data;
      })
    );
  }

  /**
   * Delete item by push object model
   * @param url : String
   * @param model : object model
   */
  delete(url: string, model: any): Observable<ResponseModel> {
    return this.http.put<ResponseModel>(url, model).pipe(
      map((data: ResponseModel) => {
        if (data.responseStatus === ResponseStatus.success) {
          this.notifyService.notifyDelete(true);
        }
        return data;
      })
    );
  }

  /**
   * Delete item by id
   * @param url : String
   * @param id : Item deleted id
   */
  deleteById(url: string, id: number): Observable<ResponseModel> {

    return this.http.delete<ResponseModel>(url + '?id=' + id).pipe(
      map((data: ResponseModel) => {
        if (data.responseStatus === ResponseStatus.success) {
          this.notifyService.notifyDelete(true);
        }
        return data;
      })
    );
  }

}
