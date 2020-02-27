using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Models;

namespace VisionamosMusic.Mappers
{
    public static class CarsMapper
    {
        public static Car map(CarModel dto)
        {
            Car item = new Car();
            item.Id = dto.Id;
            item.IdSong = dto.Song.Id;
            item.IdUser = dto.User.Id;
            item.Date = dto.Date;

            return item;
        }

        public static CarModel map(Car dto)
        {
            SongModel song = new SongModel();
            UserModel user = new UserModel();
            if(dto.IdSongNavigation != null)
            {
                song = SongsMapper.map(dto.IdSongNavigation);
            }
            if (dto.IdUserNavigation != null)
            {
                user = UsersMapper.map(dto.IdUserNavigation);
            }
            CarModel item = new CarModel();
            item.Id = dto.Id;
            item.Date = dto.Date;
            item.Song = song;
            item.User = user;
            return item;
        }

        public static List<CarModel> map(IEnumerable<Car> listado)
        {
            List<CarModel> listaResultante = new List<CarModel>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }

        public static List<Car> map(IEnumerable<CarModel> listado)
        {
            List<Car> listaResultante = new List<Car>();
            foreach (var item in listado)
            {
                var _item = map(item);
                listaResultante.Add(_item);
            }
            return listaResultante;
        }
    }
}
