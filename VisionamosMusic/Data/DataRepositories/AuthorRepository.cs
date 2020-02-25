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
    /// Descripcion: Clase que se encarga de administrar los datos de la tabla Author en la base de datos
    /// </summary>
    public class AuthorRepository : IAuthorRepository
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
        /// Elimina un Author de la base de datos
        /// </summary>
        /// <param name="id">Identificador del Author a eliminar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje)> Delete(int id)
        {
            try
            {
                var author = await GetById(id);
                if (author.Resultado)
                {
                    this._visionamosMusicDBContext.Author.Remove(author.item);
                    await this._visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "El Author a sido eliminado");
                }
                return (author.Resultado, author.Mensaje);
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException);
            }
        }
        /// <summary>
        /// Recupera todos los Author de la base de datos
        /// </summary>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, List<Author> item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, List<Author> items)> GetAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    var authorList = this._visionamosMusicDBContext.Author.ToList();
                    if (authorList != null)
                    {
                        return (true, "Listado de Author encontrados", authorList);
                    }
                    else
                    {
                        return (true, "No se recuperaron Author", null);
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
        /// Obtiene el Author por el id enviado
        /// </summary>
        /// <param name="id">Parametro para consultar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Album item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Author item)> GetById(int id)
        {
            try
            {
                var find = await this._visionamosMusicDBContext.Author.FindAsync(id);
                if (find != null)
                {
                    return (true, "Datos del Author", find);
                }
                else
                {
                    return (false, "El Author con id " + id.ToString() + " no existe", null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message + " | " + ex.InnerException, null);
            }
        }
        /// <summary>
        /// Inserta un nuevo Author al modelo
        /// </summary>
        /// <param name="element">Author a insertar</param>
        /// <returns>Devuelve el modelo (bool Resultado, string Mensaje, Author item) con la informacion</returns>
        public async Task<(bool Resultado, string Mensaje, Author item)> Insert(Author element)
        {
            try
            {
                element.Id = ObtenerMaximoConsecutivo() + 1;
                await this._visionamosMusicDBContext.AddAsync(element);
                await this._visionamosMusicDBContext.SaveChangesAsync();
                return (true, "Author creado exitosamente", element);
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
        public async Task<(bool Resultado, string Mensaje, Author item)> Update(int id, Author element)
        {
            try
            {
                var author = await GetById(id);
                if (author.Resultado)
                {
                    author.item.Name = element.Name;
                    author.item.Song = element.Song;
                    _visionamosMusicDBContext.Author.Update(author.item);
                    await _visionamosMusicDBContext.SaveChangesAsync();
                    return (true, "Author actualizado", author.item);
                }
                else
                {
                    return (false, "No se encontro Author con el identificador especificado", null);
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
                return this._visionamosMusicDBContext.Author.Select(p => p.Id).DefaultIfEmpty(0).Max();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
    }
}
