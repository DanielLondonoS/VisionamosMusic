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
    /// Descripcion: Interface que se encarga de exponer los metodos publicos del servicio User
    /// </summary>
    public interface IUserService
    {
        Task<(bool Resultado, string Mensaje, List<UserModel> items)> GetListUsers();
        Task<(bool Resultado, string Mensaje, UserModel item)> AddNewUser(UserModel user);
        Task<(bool Resultado, string Mensaje, UserModel item)> ValidateUser(UserLoginModel data);
    }
}
