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
    /// Descripcion: Clase que se encarga de administrar los servicios que se comunican con el repositorio Album
    /// </summary>
    public class AlbumService : IAlbumService
    {
        #region Propiedades
        private readonly IAlbumRepository _albumRepository;
        #endregion
        #region Constructor
        public AlbumService(IAlbumRepository albumRepository)
        {
            this._albumRepository = albumRepository;
        }
        #endregion
        #region Metodos Publicos
        public async Task<(bool Resultado, string Mensaje, List<AlbumModel> items)> GetListAlbums()
        {
            try
            {
                var result = await this._albumRepository.GetAll();
                if (result.Resultado)
                {
                    return (true, "Se recupero listado de Albums:", AlbumMapper.map(result.items));
                }
                else
                {
                    return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Obtener el listado de Albums: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        public async Task<(bool Resultado, string Mensaje, AlbumModel item)> AddNewAlbum(AlbumModel album)
        {
            try
            {
                if (album != null)
                {
                    var val = AlbumMapper.map(album);
                    var result = await this._albumRepository.Insert(val);
                    if (result.Resultado)
                    {
                        return (true, "El album se creo exitosamente", AlbumMapper.map(result.item));
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
                return (false, "Error al Crear un Album: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }

        public async Task<(bool Resultado, string Mensaje, List<AlbumModel> items)> GetListAlbumsByAuthor(int id)
        {
            try
            {
                var result = await this._albumRepository.GetAlbumByAuthor(id);
                if (result.Resultado)
                {
                    List<AlbumModel> list = AlbumMapper.map(result.item);
                    return (true, "Albunes encontrados", list);
                }
                else
                {
                    return (true, result.Mensaje, null);

                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Crear un Album: Messaje :" + ex.Message + " | " + ex.InnerException, null);

            }
        }
        #endregion
        #region Metodos Privados

        #endregion

    }
}
