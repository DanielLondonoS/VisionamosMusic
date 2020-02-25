using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Models;

namespace VisionamosMusic.Services.Interfaces
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Interface que se encarga de exponer los metodos publicos del servicio Album
    /// </summary>
    public interface ISongService
    {
        Task<(bool Resultado, string Mensaje, List<SongModel> items)> GetListSongs();
        Task<(bool Resultado, string Mensaje, SongModel item)> AddNewSong(SongModel song);
    }
}
