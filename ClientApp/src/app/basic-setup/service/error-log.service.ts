import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { map } from 'rxjs';
import { ErrorLogPagination, IErrorLogPagination } from '../models/errorLogPagination';
import { ErrorLog } from '../models/ErrorLog';

@Injectable({
  providedIn: 'root'
})
export class ErrorLogService {
  
    baseUrl = environment.apiUrl;
      ErrorLog: ErrorLog[] = [];
      ErrorLogPagination = new ErrorLogPagination();

  constructor(private http: HttpClient) { }

    getErrorLog(pageNumber, pageSize,searchText) {
  
      let params = new HttpParams();
  
      params = params.append('searchText', searchText.toString());
      params = params.append('pageNumber', pageNumber.toString());
      params = params.append('pageSize', pageSize.toString());
      return this.http.get<IErrorLogPagination>(this.baseUrl + '/error-log/get-ErrorLogs', { observe: 'response', params })
      .pipe(
        map(response => {
          this.ErrorLog = [...this.ErrorLog, ...response.body.items];
          this.ErrorLogPagination = response.body;
          return this.ErrorLogPagination;
        })
      );
    }

    delete(id){
      return this.http.delete(this.baseUrl + '/error-log/delete-ErrorLog/'+id);
    }
}
