import { Injectable , Inject} from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ISongs } from 'src/interfaces/ISons';
import { IAuthors } from 'src/interfaces/IAuthors';
import { IAlbums } from 'src/interfaces/IAlbums';
@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  url: string = "";
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  listadoDeAlbunes() {
    return this.http.get<any>(this.url + 'api/Album/listadoAlbunes', { headers:new HttpHeaders().set('content-type','application/json')});
  }

  agregarAlbum(album: IAlbums) {
    return this.http.post(this.url + 'api/Album/agregarAlbum', album, { headers: new HttpHeaders().set('content-type', 'application/json') })
  }

  listadoDeAlbunesPorAutor(id :number) {
    return this.http.get<any>(this.url + 'api/Album/listadoAlbunesPorAutor?id='+id, { headers: new HttpHeaders().set('content-type', 'application/json') });
  }

  
}
