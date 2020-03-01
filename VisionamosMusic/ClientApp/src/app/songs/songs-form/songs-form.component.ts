import { Component } from '@angular/core';
import { IUsers } from 'src/interfaces/IUsers';
import { SongsService } from 'src/services/songs.service';
import { ISongs } from 'src/interfaces/ISons';
import { ActivatedRoute, Router } from '@angular/router';
import { IAuthors } from 'src/interfaces/IAuthors';
import { AuthorService } from 'src/services/author.service';
import { IAlbums } from 'src/interfaces/IAlbums';
import { AlbumService } from 'src/services/album.service';

@Component({
  selector: 'app-songs-form',
  templateUrl: './songs-form.component.html',
  styleUrls: ['./songs-form.component.css']
})
export class SongsFormComponent {
  datosUsuario: IUsers = { id: 0, nombre: '', contrasena: '', usuario: '', esAdmin: 'N/A' };
  song: ISongs = {
    id: 0,
    album: "",
    author: "",
    name : ""
  };
  listaAutores: IAuthors[];
  listaAlbunes: IAlbums[];
  mensaje: string = "";
  type: any = 'new';
  constructor(public songService: SongsService, public authorService: AuthorService,
    public albumService: AlbumService, private route: ActivatedRoute,
    private router: Router) {
    this.datosUsuario = JSON.parse(localStorage.getItem('usuario'));
    console.log(this.datosUsuario)
    if (this.datosUsuario == undefined || this.datosUsuario == null) {
      this.datosUsuario = { id: 0, nombre: '', contrasena: '', usuario: '', esAdmin: 'N/A' };
    }
    this.route.data.subscribe(res => {
      console.log(res);
      this.type = res['type'];
    }, error => {
      console.log(error);
    });

    this.cargarAutores();
    this.cargarAlbums();
  }

  ngOnInit() {
    
  }

  cargarAutores() {
    this.authorService.listadoDeAutores()
      .subscribe(res => {
        console.log({ cargarAutores: res });
        if (res['isSuccess']) {
          this.listaAutores = res['listAuthors'];
          console.log(this.listaAutores);
        } else {
          alert(res['message']);
        }
      }, error => {
        console.log({ cargarAutores: error });
      })
  }

  cargarAlbums() {
    this.albumService.listadoDeAlbunes()
      .subscribe(res => {
        console.log({ cargarAlbums: res });
        if (res['isSuccess']) {
          this.listaAlbunes = res['listAlbumns'];
          console.log(this.listaAlbunes);
        } else {
          alert(res['message']);
        }
      }, error => {
        console.log({ cargarAlbums: error });
      })
  }

  loadAlbumByAuthor(id: number) {
    this.albumService.listadoDeAlbunesPorAutor(this.song.author)
      .subscribe(res => {
        console.log({ cargarAlbums: res });
        if (res['isSuccess']) {
          this.listaAlbunes = res['listAlbumns'];
          console.log(this.listaAlbunes);
        } else {
          alert(res['message']);
        }
      }, error => {
        console.log({ cargarAlbums: error });
      })
  }

  agregarCancion() {
    console.log(this.song);
    let autor = this.listaAutores.find(f => f.id == this.song.author);
    this.song.author = autor;
    let album = this.listaAlbunes.find(f => f.id == this.song.album);
    this.song.album = album;
    console.log(this.song);

    this.songService.agregarCancion(this.song)
      .subscribe(res => {
        console.log({ agregarCacion: res });
        if (res['isSuccess']) {
          alert(res['Message']);
          this.router.navigate(['/song'])
        } else {
          alert(res['Message']);
        }
      }, error => {
        console.log({ agregarSongError: error });
      })
  }
}
