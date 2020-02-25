using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataRepositories.Interfaces;
using VisionamosMusic.Mappers;
using VisionamosMusic.Models;
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
        #endregion
        #region Metodos Publicos
        public async Task<(bool Resultado, string Mensaje, List<AuthorModel> items)> GetListAuthor()
        {
            try
            {
                var result = await this._authorRepository.GetAll();
                if (result.Resultado)
                {
                    return (true, "Se recupero listado de Author:", AuthorMapper.map(result.items));
                }
                else
                {
                    return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Obtener el listado de Authors: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        public async Task<(bool Resultado, string Mensaje, AuthorModel item)> AddNewAuthor(AuthorModel author)
        {
            try
            {
                if (author != null)
                {
                    var val = AuthorMapper.map(author);
                    var result = await this._authorRepository.Insert(val);
                    if (result.Resultado)
                    {
                        return (true, "El author se creo exitosamente", AuthorMapper.map(result.item));
                    }
                    else
                    {
                        return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                    }
                }
                else
                {
                    return (false, "Ocurrio un problema en el modelo", null);
                }

            }
            catch (Exception ex)
            {
                return (false, "Error al Crear un author: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        #endregion
        #region Metodos Privados

        #endregion
    }
}
