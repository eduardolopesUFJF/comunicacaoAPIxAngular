import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { environment } from "../../environments/environment";
import 'rxjs/Rx';

@Injectable()
export abstract class BaseService {

protected headers: Headers;
protected requestOptions: RequestOptions;

protected apiControllerUrl;

    constructor(protected http: Http, rota: string) {
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.requestOptions = new RequestOptions({ headers: this.headers, withCredentials: true  });
    
        this.apiControllerUrl = environment.urlAPI + rota;
    }

    protected handleError(error: any) {
    if (error.status == '401' || error.status == '403') {
      location.href = environment.urlAPI;
    } else {
      return Promise.reject(error);
    }
  }
}