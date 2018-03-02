import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, FormBuilder, FormGroup, Validators , ReactiveFormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login.component';
import { HttpModule } from '@angular/http';
import { BookComponent } from './BooksTab/book.component'


@NgModule({
  imports: [BrowserModule, FormsModule, HttpModule, ReactiveFormsModule],
  declarations: [ AppComponent , LoginComponent, BookComponent],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
