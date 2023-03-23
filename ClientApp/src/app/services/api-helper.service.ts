import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class ApiHelperService {

  baseUrl = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  get<TResponse>(uri: string, params = new HttpParams(), headers = new HttpHeaders()): Observable<TResponse> {
    return this.http.get<TResponse>(this.baseUrl + uri + (uri.indexOf('?') == -1 ? "" : "?"), { headers, params });
  }

  put<TData, TResponse>(uri: string, data: TData, params = new HttpParams()): Observable<TResponse> {
    return this.http.put<TResponse>(this.baseUrl + uri, data, { params });
  }

  delete<TResponse>(uri: string, params = new HttpParams()): Observable<TResponse> {
    return this.http.delete<TResponse>(this.baseUrl + uri, { params });
  }

}
