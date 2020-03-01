using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;

namespace VisionamosMusic.Data.DataRepositories.Interfaces
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Interface que se encarga de exponer los metodos publicos de  la clase
    /// </summary>
    public interface IUserRepository: IRepository<Users>
    {
        Task<(bool Resultado, string Mensaje, Users item)> ValidateUser(string usuario, string contrasena);
    }
}
