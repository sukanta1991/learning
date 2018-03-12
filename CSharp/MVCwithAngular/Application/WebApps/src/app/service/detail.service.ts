import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class DetailService {
    constructor(private http: Http) { }
    private detailUrl: string = 'http://localhost:5880/api/details/';
    private handleError(error: any) {
        console.log("err");
        let errMsg = (error.Message) ? error.Message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        console.log("oops got error");
        return Observable.throw(errMsg);
    }
    getDetails(id: string): Observable<any> {
        let headers = new Headers({ 'Accept': 'application/json'});
        let options = new RequestOptions({ headers: headers });
        return this.http.get(this.detailUrl + id, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
}
