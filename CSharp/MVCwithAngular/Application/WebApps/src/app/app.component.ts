import { Component, Input, ElementRef, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit  {

    name = 'Angular';
    constructor(private elementRef: ElementRef, private _router: Router) { }

    username: string = this.elementRef.nativeElement.getAttribute('username')
    ngOnInit() {
        this._router.navigate(['/home/'+this.username]);
    }
}
