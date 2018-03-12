import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AboutComponent } from './About/about.component';
import { BookComponent} from './Book/book.component';
import { ContactComponent} from './Contact/contact.component';
import { SkillComponent } from './Skill/skill.component';
import { HomeComponent } from './Home/home.component';

const appRoutes: Routes = [{ path: 'home/:id', component: HomeComponent },
    { path: 'about/:id', component: AboutComponent},
    { path: 'book/:id', component: BookComponent},
    { path: 'contact/:id', component: ContactComponent},
    { path: 'skill/:id', component: SkillComponent }
]

@NgModule({ imports: [RouterModule.forRoot(appRoutes)], exports: [RouterModule] })

export class AppRoutingModeule{}
