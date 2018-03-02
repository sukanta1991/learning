import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: `<h1>Hello {{name}}</h1>
                <appLogin></appLogin>`,
})
export class AppComponent  { name = 'Sukanta Saha App'; }
