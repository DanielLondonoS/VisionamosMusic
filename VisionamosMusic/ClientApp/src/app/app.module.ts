import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SongsComponent } from './songs/songs.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { LoginService } from 'src/services/login.service';
import { SongsService } from 'src/services/songs.service';
import { SongsFormComponent } from './songs/songs-form/songs-form.component';
import { AuthorService } from 'src/services/author.service';
import { AlbumService } from 'src/services/album.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SongsComponent,
    FetchDataComponent,
    LoginComponent,
    SongsFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'songs', component: SongsComponent },
      { path: 'songs-form', component: SongsFormComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'login', component: LoginComponent },
    ])
  ],
  providers: [LoginService, SongsService, AuthorService, AlbumService],
  bootstrap: [AppComponent]
})
export class AppModule { }
