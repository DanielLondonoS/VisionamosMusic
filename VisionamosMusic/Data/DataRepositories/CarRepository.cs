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
    /// Descripcion: Clase que se encarga de administrar los datos de la tabla Car en la base de datos
    /// </summary>
    public class CarRepository : ICarRepository
    {
        #region Propiedades
        private readonly VisionamosMusicDBContext _visionamosMusicDBContext;
        #endregion
        #region Constructor
        public CarRepository(VisionamosMusicDBContext visionamosMusicDBContext)
        {
            this._visionamosMusicDBContext = visionamosMusicDBContext;
        }
        #endregion
        #region Metodos publicos
        /// <summary>
        /// Elimina un Car de la base de datos
        /// </summary>
        /// <param name="id">Identificador del Car a eliminar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje)> Delete(int id)
        {
            try
            {
                var Car = await GetById(id);
                if (Car.Resultado)
                {
                    this._visionamosMusicDBContext.Car.Remove(Car.item);
                    await this._visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "El Car a sido eliminado");
                }
                return (Car.Resultado, Car.Mensaje);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException);
            }
        }
        /// <summary>
        /// Recupera todos los Car de la base de datos
        /// </summary>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, List<Author> item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, List<Car> items)> GetAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var CarList = this._visionamosMusicDBContext.Car
                    .Join(
                        this._visionamosMusicDBContext.Song,
                        Car => Car.IdSong,
                        Song => Song.Id,
                        (Car, Song) => new Car
                        {
                            Id = Car.Id,
                            IdSong = Car.IdSong,
                            Date = Car.Date,
                            IdUser = Car.IdUser,
                            IdSongNavigation = Song,
                            IdUserNavigation = Car.IdUserNavigation
                        }
                    )
                    .Join(
                        this._visionamosMusicDBContext.Users,
                        Car => Car.IdUser,
                        User => User.Id,
                        (_Car,User) => new Car
                        {
                            Id = _Car.Id,
                            IdSong = _Car.IdSong,
                            Date = _Car.Date,
                            IdUser = _Car.IdUser,
                            IdSongNavigation = _Car.IdSongNavigation,
                            IdUserNavigation = User
                        }).ToList();                    
    
                    if (CarList != null)
                    {
                        return (true, "Listado de Car encontrados", CarList);
                    }
                    else
                    {
                        return (true, "No se recuperaron Car", null);
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
        /// Obtiene el Car por el id enviado
        /// </summary>
        /// <param name="id">Parametro para consultar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Car item)> GetById(int id)
        {
            try
            {
                var find = await this._visionamosMusicDBContext.Car.FindAsync(id);
                if (find != null)
                {
                    return (true, "Datos del Car", find);
                }
                else
                {
                    return (false, "El Car con id " + id.ToString() + " no existe", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Inserta un nuevo Car al modelo
        /// </summary>
        /// <param name="element">Car a insertar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Car item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Car item)> Insert(Car element)
        {
            try
            {
                element.Id = ObtenerMaximoConsecutivo() + 1;
                await this._visionamosMusicDBContext.AddAsync(element);
                await this._visionamosMusicDBContext.SaveChangesAsync();
                return (true, "Car creado exitosamente", element);
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
        public async Task<(bool Resultado, string Mensaje, Car item)> Update(int id, Car element)
        {
            try
            {
                var Car = await GetById(id);
                if (Car.Resultado)
                {
                    Car.item.IdSong = element.IdSong;
                    Car.item.IdUser = element.IdUser;
                    Car.item.Date = element.Date;                 
                    _visionamosMusicDBContext.Car.Update(Car.item);
                    await _visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "Car actualizado", Car.item);
                }
                else
                {
                    return (false, "No se encontro Car con el identificador especificado", null);
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
                return this._visionamosMusicDBContext.Car.Select(p => p.Id).DefaultIfEmpty(0).Max();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
