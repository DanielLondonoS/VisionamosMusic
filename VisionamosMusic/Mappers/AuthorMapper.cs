using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Models;

namespace VisionamosMusic.Mappers
{
    public static class AuthorMapper
    {
        public static Author map(AuthorModel dto)
        {
            Author item = new Author();
            item.Name = dto.Name;
            item.Id = dto.Id;
            return item;
        }

        public static AuthorModel map(Author dto)
        {
            AuthorModel item = new AuthorModel();
            item.Name = dto.Name;
            item.Id = dto.Id;
            return item;
        }

        public static List<AuthorModel> map(IEnumerable<Author> listado)
        {
            List<AuthorModel> listaResultante = new List<AuthorModel>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }

        public static List<Author> map(IEnumerable<AuthorModel> listado)
        {
            List<Author> listaResultante = new List<Author>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }
    }
}
