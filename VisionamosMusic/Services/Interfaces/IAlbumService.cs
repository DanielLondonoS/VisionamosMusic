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
    public interface IAlbumService
    {
        Task<(bool Resultado, string Mensaje, List<AlbumModel> items)> GetListAlbums();
        Task<(bool Resultado, string Mensaje, List<AlbumModel> items)> GetListAlbumsByAuthor(int id);
        Task<(bool Resultado, string Mensaje, AlbumModel item)> AddNewAlbum(AlbumModel album);
    }
}
