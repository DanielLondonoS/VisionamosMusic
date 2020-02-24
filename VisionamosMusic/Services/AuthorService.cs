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
    /// Descripcion: Clase que se encarga de administrar los servicios que se comunican con el repositorio Author
    /// </summary>
    public class AuthorService : IAuthorService
    {
        #region Propiedades
        private readonly IAuthorRepository _authorRepository;
        #endregion
        #region Constructor
        public AuthorService(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }
        #region
        #region Metodos Publicos

        #region
        #region Metodos Privados

        #region
    }
}
