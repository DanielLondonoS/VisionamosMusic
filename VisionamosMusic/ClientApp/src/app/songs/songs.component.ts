import { Component } from '@angular/core';
import { IUsers } from 'src/interfaces/IUsers';
import { SongsService } from 'src/services/songs.service';
import { ISongs } from 'src/interfaces/ISons';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls:['./songs.component.css']
})
export class SongsComponent {
  datosUsuario: IUsers = { id: 0, nombre: '', contrasena: '', usuario: '', esAdmin: 'N/A' };
  songsList: ISongs[];
  mensaje: string = "";

  constructor(public songService: SongsService, private route: ActivatedRoute, private router: Router) {
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

  agregarCancion() {
    this.router.navigate(['/songs-form', {type:'new'}]);
  }
}
