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
    /// Descripcion: Clase que se encarga de administrar los datos de la tabla Album en la base de datos
    /// </summary>
    public class AlbumsRepository : IAlbumRepository
    {
        #region Propiedades
        private readonly VisionamosMusicDBContext _visionamosMusicDBContext;
        #endregion
        #region Constructor
        public AlbumsRepository(VisionamosMusicDBContext visionamosMusicDBContext)
        {
            this._visionamosMusicDBContext = visionamosMusicDBContext;
        }
        #endregion
        #region Metodos publicos
        /// <summary>
        /// Elimina un album de la base de datos
        /// </summary>
        /// <param name="id">Identificador del album a eliminar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje)> Delete(int id)
        {
            try
            {
                var album = await GetById(id);
                if (album.Resultado)
                {
                    this._visionamosMusicDBContext.Album.Remove(album.item);
                    await this._visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "El album a sido eliminado");
                }
                return (album.Resultado, album.Mensaje);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException);
            }
        }
        /// <summary>
        /// Recupera todos los albunes de la base de datos
        /// </summary>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, List<Album> item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, List<Album> items)> GetAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var albumList = this._visionamosMusicDBContext.Album
                    .Join(
                        this._visionamosMusicDBContext.Author,
                        album => album.IdAutor,
                        author => author.Id,
                      (album, author) => new Album {
                          Id = album.Id,
                          IdAutor = album.IdAutor,
                          Name = album.Name,
                          PublishDate = album.PublishDate,
                          IdAutorNavigation = album.IdAutorNavigation,
                          Song = album.Song
                      }).ToList();
                   
                    //var albumList = (
                    //// instance from context
                    //from a in this._visionamosMusicDBContext.Author
                    //    //join to bring useful data
                    //join c in this._visionamosMusicDBContext.Album on a.Id equals c.IdAutor
                    //select new Album
                    //{
                    //    Id = c.Id,
                    //    Name = c.Name,
                    //    IdAutor = c.IdAutor,
                    //    IdAutorNavigation = c.IdAutorNavigation,
                    //    PublishDate = c.PublishDate,
                    //    Song = c.Song

                    //}).ToList();//this._visionamosMusicDBContext.Album.ToList();
                    if (albumList != null)
                    {
                        return (true, "Listado de albunes encontrados", albumList);
                    }
                    else
                    {
                        return (true, "No se recuperaron albunes", null);
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
        /// Obtiene el album por el id enviado
        /// </summary>
        /// <param name="id">Parametro para consultar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Album item)> GetById(int id)
        {
            try
            {
                var find = await this._visionamosMusicDBContext.Album.FindAsync(id);
                if(find != null)
                {
                    return (true, "Datos del album", find);
                }
                else
                {
                    return (false, "El album con id " + id.ToString() + " no existe", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Inserta un nuevo album al modelo
        /// </summary>
        /// <param name="element">Album a insertar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Album item)> Insert(Album element)
        {
            try
            {
                element.Id = ObtenerMaximoConsecutivo() + 1;
                await this._visionamosMusicDBContext.AddAsync(element);
                await this._visionamosMusicDBContext.SaveChangesAsync();
                
                return (true, "Album creado exitosamente", element);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Actualiza la informacion del album
        /// </summary>
        /// <param name="id">Identificador del album</param>
        /// <param name="element">Modelo a actualizar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Album item)> Update(int id, Album element)
        {
            try
            {
                var album = await GetById(id);
                if(album.Resultado)
                {
                    album.item.Name = element.Name;
                    album.item.PublishDate = element.PublishDate;
                    album.item.Song = element.Song;
                    _visionamosMusicDBContext.Album.Update(album.item);
                    await _visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "Album actualizado", album.item);
                }
                else
                {
                    return (false, "No se encontro album con el identificador especificado", null);
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
                return this._visionamosMusicDBContext.Album.Select(p => p.Id).DefaultIfEmpty(0).Max();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
