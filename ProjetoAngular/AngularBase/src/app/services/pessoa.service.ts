import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { environment } from '../../environments/environment';
import { BaseService } from "./base.service";
import { Pessoa } from "../models/pessoa";
import { Observable } from "rxjs/Observable";

@Injectable()
export class PessoaService extends BaseService {
    constructor(http: Http) {
        super(http, 'pessoa/');
    }
    //Métodos para API ASP.NET FRAMEWORK 4.6
    public buscarTodas(): Observable<Pessoa[]>{
        return this.http.get(this.apiControllerUrl+'/getAll', this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    public buscarPeloId(pessoaId : number): Observable<Pessoa> {
        return this.http.get(this.apiControllerUrl + '/getById/' + pessoaId, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    //Métodos para API ASP.NET CORE 2.0
    public buscarTodasCore(): Observable<Pessoa[]>{
        return this.http.get(this.apiControllerUrl, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
    public buscarPeloIdCore(pessoaId : number): Observable<Pessoa> {
        return this.http.get(this.apiControllerUrl + '/' + pessoaId, this.requestOptions)
            .map(res => res.json())
            .catch(this.handleError);
    }
}