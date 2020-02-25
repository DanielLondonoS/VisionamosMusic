using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Models;

namespace VisionamosMusic.Mappers
{
    public static class AlbumMapper
    {
        public static Album map(AlbumModel dto)
        {
            Author autor = new Author();
            autor = AuthorMapper.map(dto.Autor);

            Album item = new Album();
            item.Name = dto.Name;
            item.Id = dto.Id;
            item.PublishDate = dto.PublishDate;
            item.IdAutor = dto.Autor.Id;
            return item;
        }

        public static AlbumModel map(Album dto)
        {
            AuthorModel autor = new AuthorModel();
            if(dto.IdAutorNavigation != null)
            {
                autor = AuthorMapper.map(dto.IdAutorNavigation);
            }
            
            AlbumModel item = new AlbumModel();
            item.Name = dto.Name;
            item.Id = dto.Id;
            item.PublishDate = dto.PublishDate;
            item.Autor = autor;
            return item;
        }

        public static List<AlbumModel> map(IEnumerable<Album> listado)
        {
            List<AlbumModel> listaResultante = new List<AlbumModel>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }

        public static List<Album> map(IEnumerable<AlbumModel> listado)
        {
            List<Album> listaResultante = new List<Album>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }
    }
}
