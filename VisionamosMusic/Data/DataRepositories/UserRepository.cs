using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;
using VisionamosMusic.Data.DataRepositories.Interfaces;

namespace VisionamosMusic.Data.DataRepositories
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Clase que se encarga de administrar los datos de la tabla Users en la base de datos
    /// </summary>
    public class UserRepository : IUserRepository
    {
        #region Propiedades
        private readonly VisionamosMusicDBContext _visionamosMusicDBContext;
        #endregion
        #region Constructor
        public UserRepository(VisionamosMusicDBContext visionamosMusicDBContext)
        {
            this._visionamosMusicDBContext = visionamosMusicDBContext;
        }
        #endregion
        #region Metodos publicos
        /// <summary>
        /// Elimina un Users de la base de datos
        /// </summary>
        /// <param name="id">Identificador del Users a eliminar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje)> Delete(int id)
        {
            try
            {
                var users = await GetById(id);
                if (users.Resultado)
                {
                    this._visionamosMusicDBContext.Users.Remove(users.item);
                    await this._visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "El Users a sido eliminado");
                }
                return (users.Resultado, users.Mensaje);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException);
            }
        }
        /// <summary>
        /// Recupera todos los Users de la base de datos
        /// </summary>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, List<Author> item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, List<Users> items)> GetAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var UsersList = this._visionamosMusicDBContext.Users.ToList();                    
    
                    if (UsersList != null)
                    {
                        return (true, "Listado de Users encontrados", UsersList);
                    }
                    else
                    {
                        return (true, "No se recuperaron Users", null);
                    }
                });
                return await task;
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Obtiene el Users por el id enviado
        /// </summary>
        /// <param name="id">Parametro para consultar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Users item)> GetById(int id)
        {
            try
            {
                var find = await this._visionamosMusicDBContext.Users.FindAsync(id);
                if (find != null)
                {
                    return (true, "Datos del Users", find);
                }
                else
                {
                    return (false, "El Users con id " + id.ToString() + " no existe", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Inserta un nuevo Users al modelo
        /// </summary>
        /// <param name="element">Users a insertar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Users item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Users item)> Insert(Users element)
        {
            try
            {
                element.Id = ObtenerMaximoConsecutivo() + 1;
                await this._visionamosMusicDBContext.AddAsync(element);
                await this._visionamosMusicDBContext.SaveChangesAsync();
                return (true, "Users creado exitosamente", element);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Actualiza la informacion del User
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <param name="element">Modelo a actualizar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, User item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Users item)> Update(int id, Users element)
        {
            try
            {
                var users = await GetById(id);
                if (users.Resultado)
                {
                    users.item.Nombre = element.Nombre;
                    users.item.Usuario = element.Usuario;
                    users.item.Contrasena = element.Contrasena;
                    users.item.EsAdmin = element.EsAdmin;                    
                    _visionamosMusicDBContext.Users.Update(users.item);
                    await _visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "Users actualizado", users.item);
                }
                else
                {
                    return (false, "No se encontro Users con el identificador especificado", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        #endregion
        #region Metodos Privados
        /// <summary>
        /// Obtiene el maximo consecutivo en la tabla.
        /// </summary>
        /// <returns>Consecutivo siguiente</returns>
        private int ObtenerMaximoConsecutivo()
        {
            try
            {
                return this._visionamosMusicDBContext.Users.Select(p => p.Id).DefaultIfEmpty(0).Max();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
