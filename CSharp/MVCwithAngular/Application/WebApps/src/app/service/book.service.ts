import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { Book } from './book';

@Injectable()
export class BookService {
    constructor(private http: Http) { }
    private bookUrl: string = 'http://localhost:5880/api/book/';
    
    private handleError(error: any) {
        console.log("err");
        let errMsg = (error.Message) ? error.Message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        console.log("oops got error");
        return Observable.throw(errMsg);
    }

    getBooksList(): Observable<any> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(this.bookUrl, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    addBook(model: Book): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append("Accept", "application/json");
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(model);
        return this.http.post(this.bookUrl, body, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);

    }
    deleteBook(id: number): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.delete(this.bookUrl + id, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
    updateBook(id: number, model: Book): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify(model);
        return this.http.put(this.bookUrl + id, body, options)
            .map((response: Response) => response.status == 204 ? 1 : 0)
            .catch(this.handleError);
    }
}
