import { Injectable , Inject} from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string = "";
  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  validarUsuario(data:object) {
    return this.http.post<any>(this.url + 'api/User/validarUsuario', JSON.stringify(data), { headers:new HttpHeaders().set('content-type','application/json')});
  }
}
