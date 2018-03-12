import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { AppRoutingModeule } from './app-routing.module'
import { AboutComponent } from './About/about.component';
import { BookComponent } from './Book/book.component';
import { ContactComponent } from './Contact/contact.component';
import { SkillComponent } from './Skill/skill.component';
import { HomeComponent } from './Home/home.component';
import { FilterPipe } from './Factory/filter.pipe';
import { PaginationPipe } from './Factory/pagination.pipe';

@NgModule({
    imports: [BrowserModule, AppRoutingModeule, FormsModule, HttpModule, ReactiveFormsModule],
  declarations: [ AppComponent, AboutComponent,BookComponent, ContactComponent,SkillComponent, HomeComponent , FilterPipe,PaginationPipe],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
