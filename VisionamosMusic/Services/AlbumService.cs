using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataRepositories.Interfaces;
using VisionamosMusic.Services.Interfaces;

namespace VisionamosMusic.Services
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Clase que se encarga de administrar los servicios que se comunican con el repositorio Album
    /// </summary>
    public class AlbumService : IAlbumService
    {
        #region Propiedades
        private readonly IAlbumRepository _albumRepository;
        #endregion
        #region Constructor
        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }
        #region
        #region Metodos Publicos

        #region
        #region Metodos Privados

        #region

    }
}
