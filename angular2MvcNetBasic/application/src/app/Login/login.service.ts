import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { user } from './user';

@Injectable()
export class LoginService {
    constructor(private http:Http){}
    private loginUrl: string = 'http://localhost:2692/api/LoginByUsernamePassword_Result/';

    private handleError(error: any) {
        //console.log("err");
        let errMsg = (error.Message) ? error.Message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
       // console.log("oops got error");
        return Observable.throw(errMsg);
    }
    validateUser(userDetails: user): Observable<any>{
        //console.log("inside service");
        let body = { "username": userDetails.userName, "password": userDetails.password };
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append("Accept", "application/json");
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.loginUrl, body,options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

}
