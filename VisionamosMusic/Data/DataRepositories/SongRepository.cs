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
    /// Descripcion: Clase que se encarga de administrar los datos de la tabla Song en la base de datos
    /// </summary>
    public class SongRepository : IRepository<Song>, ISongRepository
    {
        #region Propiedades
        private readonly VisionamosMusicDBContext _visionamosMusicDBContext;
        #endregion
        #region Constructor
        public AuthorRepository(VisionamosMusicDBContext visionamosMusicDBContext)
        {
            this._visionamosMusicDBContext = visionamosMusicDBContext;
        }
        #endregion
        #region Metodos publicos
        /// <summary>
        /// Elimina un Song de la base de datos
        /// </summary>
        /// <param name="id">Identificador del Song a eliminar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje)> Delete(int id)
        {
            try
            {
                var song = await GetById(id);
                if (song.Resultado)
                {
                    this._visionamosMusicDBContext.Song.Remove(song.item);
                    await this._visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "El Song a sido eliminado");
                }
                return (song.Resultado, song.Mensaje);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException);
            }
        }
        /// <summary>
        /// Recupera todos los Song de la base de datos
        /// </summary>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, List<Author> item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, List<Song> items)> GetAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var authorList = this._visionamosMusicDBContext.Song.ToList();
                    if (authorList != null)
                    {
                        return (true, "Listado de Song encontrados", authorList);
                    }
                    else
                    {
                        return (true, "No se recuperaron Song", null);
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
        /// Obtiene el Song por el id enviado
        /// </summary>
        /// <param name="id">Parametro para consultar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Song item)> GetById(int id)
        {
            try
            {
                var find = await this._visionamosMusicDBContext.Song.FindAsync(id);
                if (find != null)
                {
                    return (true, "Datos del Song", find);
                }
                else
                {
                    return (false, "El Song con id " + id.ToString() + " no existe", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Inserta un nuevo Song al modelo
        /// </summary>
        /// <param name="element">Song a insertar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Song item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Song item)> Insert(Song element)
        {
            try
            {
                element.Id = ObtenerMaximoConsecutivo() + 1;
                await this._visionamosMusicDBContext.AddAsync(element);
                await this._visionamosMusicDBContext.SaveChangesAsync();
                return (true, "Song creado exitosamente", element);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Actualiza la informacion del Author
        /// </summary>
        /// <param name="id">Identificador del autor</param>
        /// <param name="element">Modelo a actualizar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Author item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Song item)> Update(int id, Song element)
        {
            try
            {
                var song = await GetById(id);
                if (song.Resultado)
                {
                    song.item.Name = element.Name;
                    song.item.Album = element.Album;
                    song.item.Author = element.Author;
                    _visionamosMusicDBContext.Song.Update(song.item);
                    await _visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "Song actualizado", song.item);
                }
                else
                {
                    return (false, "No se encontro Song con el identificador especificado", null);
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
                return this._visionamosMusicDBContext.Song.Select(p => p.Id).DefaultIfEmpty(0).Max();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
