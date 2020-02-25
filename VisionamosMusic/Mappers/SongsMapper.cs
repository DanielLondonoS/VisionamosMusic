using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Models;

namespace VisionamosMusic.Mappers
{
    public static class SongsMapper
    {
        public static Song map(SongModel dto)
        {
            Song item = new Song();
            item.Album = dto.Album.Id;
            item.Author = dto.Author.Id;
            item.Name = dto.Name;
            item.Id = dto.Id;
            return item;
        }

        public static SongModel map(Song dto)
        {
            AlbumModel album = new AlbumModel();
            AuthorModel autor = new AuthorModel();
            if(dto.AlbumNavigation != null)
            {
                album = AlbumMapper.map( dto.AlbumNavigation);
            }
            if(dto.AuthorNavigation != null)
            {
                autor = AuthorMapper.map(dto.AuthorNavigation);
            }
            SongModel item = new SongModel();
            item.Album = album;
            item.Author = autor;
            item.Name = dto.Name;
            item.Id = dto.Id;
            return item;
        }

        public static List<SongModel> map(IEnumerable<Song> listado)
        {
            List<SongModel> listaResultante = new List<SongModel>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }

        public static List<Song> map(IEnumerable<SongModel> listado)
        {
            List<Song> listaResultante = new List<Song>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }
    }
}
