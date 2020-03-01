import { Component, Inject, OnInit } from '@angular/core';
import { ISongs } from 'src/interfaces/ISons';
import { HttpClient } from '@angular/common/http';
import { IUsers } from 'src/interfaces/IUsers';
import { SongsService } from 'src/services/songs.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public songsList: ISongs[];
  mensaje: string = "";
  datosUsuario: IUsers = { id: 0, nombre: '', contrasena: '', usuario: '', esAdmin: 'N/A' };
  constructor(public songService:SongsService) {
    this.datosUsuario = JSON.parse(localStorage.getItem('usuario'));
    console.log(this.datosUsuario)
    if (this.datosUsuario == undefined || this.datosUsuario == null) {
      this.datosUsuario = { id: 0, nombre: '', contrasena: '', usuario: '', esAdmin: 'N/A' };
    }
    
  }

  ngOnInit() {
    this.songService.listadoCanciones()
      .subscribe(res => {
        if (res['isSuccess']) {
          this.songsList = res['listSongs']
        } else {
          this.songsList = [];
          this.mensaje = res['Message']
        }
      }, error => console.error(error));
  }

  agregarCarrito(cancion: ISongs) {
    console.log(cancion);
    console.log(this.datosUsuario);
    if (this.datosUsuario.id == 0) {
      alert('Debe de iniciar sesion o registrarse para poder agregar canciones al carrito');
    } else {

    }
  }
}


