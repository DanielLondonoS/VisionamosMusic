import { Component } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { LoginService } from 'src/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  usuario: string = "";
  contrasena: string = "";
  isExpanded = false;

  constructor(public loginService: LoginService, private route: ActivatedRoute, private router: Router,) {

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ingresar() {
    let data = new Object();
    data['usuario'] = this.usuario;
    data['contrasena'] = this.contrasena;
    this.loginService.validarUsuario(data)
      .subscribe(res => {
        console.log(res);
        if (res['isSuccess']) {
          localStorage.setItem('usuario', JSON.stringify( res['user']));
          this.router.navigate(['/']);
        } else {
          alert('Problema al ingresar, valide el usuario y contraseña y vuevla a intentarlo.')
        }
      }, error => {
        console.log({error :error})
      })

  }
}
