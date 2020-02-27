using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Models;

namespace VisionamosMusic.Mappers
{
    public static class UsersMapper
    {
        public static Users map(UserModel dto)
        {
            Users item = new Users();
            item.Nombre = dto.Nombre;
            item.Usuario = dto.Usuario;
            item.Contrasena = dto.Contrasena;
            item.EsAdmin = dto.EsAdmin;
            item.Id = dto.Id;
            return item;
        }

        public static UserModel map(Users dto)
        {
            
            UserModel item = new UserModel();
            item.Nombre = dto.Nombre;
            item.Usuario = dto.Usuario;
            item.Contrasena = dto.Contrasena;
            item.EsAdmin = dto.EsAdmin;
            item.Id = dto.Id;
            return item;
        }

        public static List<UserModel> map(IEnumerable<Users> listado)
        {
            List<UserModel> listaResultante = new List<UserModel>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }

        public static List<Users> map(IEnumerable<UserModel> listado)
        {
            List<Users> listaResultante = new List<Users>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }
    }
}
