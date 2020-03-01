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
    /// Descripcion: Clase que se encarga de administrar los servicios que se comunican con el repositorio Song
    /// </summary>
    public class UserService : IUserService
    {
        #region Propiedades
        private readonly IUserRepository _userRepository;
        #endregion
        #region Constructor
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #region
        #endregion Metodos Publicos
        public async Task<(bool Resultado, string Mensaje, List<UserModel> items)> GetListUsers()
        {
            try
            {
                var result = await this._userRepository.GetAll();
                if (result.Resultado)
                {
                    return (true, "Se recupero listado de Users:", UsersMapper.map(result.items));
                }
                else
                {
                    return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Obtener el listado de Users: Messaje :"+ex.Message+" | "+ex.InnerException, null);
            }
        }
        public async Task<(bool Resultado, string Mensaje, UserModel item)> AddNewUser(UserModel user)
        {
            try
            {
                if(user != null)
                {
                    var val = UsersMapper.map(user);
                    var result = await this._userRepository.Insert(val);
                    if (result.Resultado)
                    {
                        return (true, "El user se creo exitosamente", UsersMapper.map(result.item));
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
                return (false, "Error al Crear un Users: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }

        public async Task<(bool Resultado, string Mensaje, UserModel item)> ValidateUser(UserLoginModel data)
        {
            try
            {
                if (data != null)
                {
                    
                    var result = await this._userRepository.ValidateUser(data.Usuario, data.Contrasena);
                    if (result.Resultado)
                    {
                        return (true, "El Usuario tiene acceso", UsersMapper.map(result.item));
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
                return (false, "Error al Crear un Users: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        #endregion
        #region Metodos Privados

        #endregion
    }
}
