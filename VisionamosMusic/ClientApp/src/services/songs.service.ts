import { Injectable , Inject} from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ISongs } from 'src/interfaces/ISons';
@Injectable({
  providedIn: 'root'
})
export class SongsService {
  url: string = "";
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  listadoCanciones() {
    return this.http.get<any>(this.url + 'api/Song/listadoCanciones', { headers:new HttpHeaders().set('content-type','application/json')});
  }

  agregarCancion(song: ISongs) {
    return this.http.post(this.url + 'api/Song/agregarCancion', song, { headers: new HttpHeaders().set('content-type', 'application/json') })
  }
}
