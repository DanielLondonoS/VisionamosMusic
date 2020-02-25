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
    /// Descripcion: Interface que se encarga de exponer los metodos publicos del servicio Author
    /// </summary>
    public interface IAuthorService
    {
        Task<(bool Resultado, string Mensaje, List<AuthorModel> items)> GetListAuthor();
        Task<(bool Resultado, string Mensaje, AuthorModel item)> AddNewAuthor(AuthorModel author);
    }
}
