import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response } from '@angular/http';
import { user } from './user';
import { LoginService } from './login.service';

@Component({
    selector: 'appLogin',
    templateUrl: './login.component.html',
    providers: [LoginService]
})
export class LoginComponent {
    constructor(private loginService: LoginService) { }

    pageTitle: string = "Test Angular";
    loginTitle: string = "Login Page";
    login = new user();
    submitted = false;
    errMsg: string = "";
    onSubmit() {
        this.loginService.validateUser(this.login).subscribe(
            data => {
                        console.log(data);
                        if (data)
                        {
                            console.log("inside true");
                            this.submitted = true;
                            this.errMsg = "";
                        }
                        else
                        {
                            console.log("inside false");
                            this.login.password = "";
                            this.submitted = false;
                            this.errMsg = "Invalid Credentails";

                        }
                     }
        )
        
    }
    onLogOut() {
        this.submitted = false;
        this.login.userName = "";
        this.login.password = "";
    }
}
