import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import { Skill } from './skill';

@Injectable()
export class SkillService {
    constructor(private http: Http) { }
    private skillUrl: string = 'http://localhost:5880/api/Skill/';

    private handleError(error: any) {
        console.log("err");
        let errMsg = (error.Message) ? error.Message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        console.log("oops got error");
        return Observable.throw(errMsg);
    }

    getSkillList(id:string): Observable<any> {
        let headers = new Headers({ 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.get(this.skillUrl+id, options)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    addSkill(id:string, model: Skill): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        headers.append("Accept", "application/json");
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify({ key: id, skill:model });
        return this.http.post(this.skillUrl, body, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);

    }
    deleteSkill(id: string,skl: string): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        
        let sk: Skill = new Skill();
        sk.Skills = skl;
        
        let bodyContent = JSON.stringify({ key: id, skill: sk });
        let options = new RequestOptions({ headers: headers, body: bodyContent });
        return this.http.delete(this.skillUrl, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
    updateSkill(id: string, model: Skill): Observable<any> {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let body = JSON.stringify({ key: id, skill: model });
        return this.http.put(this.skillUrl, body, options)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
}
