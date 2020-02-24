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
    /// Descripcion: Clase que se encarga de administrar los servicios que se comunican con el repositorio Song
    /// </summary>
    public class SongService : ISongService
    {
        #region Propiedades
        private readonly ISongRepository _songRepository;
        #endregion
        #region Constructor
        public SongService(ISongRepository songRepository)
        {
            this._songRepository = songRepository;
        }
        #region
        #region Metodos Publicos

        #region
        #region Metodos Privados

        #region
    }
}
