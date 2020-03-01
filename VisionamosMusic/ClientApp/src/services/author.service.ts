import { Injectable , Inject} from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ISongs } from 'src/interfaces/ISons';
import { IAuthors } from 'src/interfaces/IAuthors';
@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  url: string = "";
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  listadoDeAutores() {
    return this.http.get<any>(this.url + 'api/Author/listadoAutores', { headers:new HttpHeaders().set('content-type','application/json')});
  }

  agregarAutor(author: IAuthors) {
    return this.http.post(this.url + 'api/Author/agregarAutor', author, { headers: new HttpHeaders().set('content-type', 'application/json') })
  }
}
