import { Component, Inject } from '@angular/core';
import { ISongs } from 'src/interfaces/ISons';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public songsList: ISongs[];
  mensaje: string = "";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ISongs[]>(baseUrl + 'api/Song/listadoCanciones').subscribe(result => {
      if (result['isSuccess']) {
        this.songsList = result['listSongs']
      } else {
        this.songsList = [];
        this.mensaje = result['Message']
      }
      
    }, error => console.error(error));
  }
}


