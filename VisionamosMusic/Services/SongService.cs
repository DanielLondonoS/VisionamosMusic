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
    public class SongService : ISongService
    {
        #region Propiedades
        private readonly ISongRepository _songRepository;
        #endregion
        #region Constructor
        public SongService(ISongRepository songRepository)
        {
            this._songRepository = songRepository;
        }
        #region
        #endregion Metodos Publicos
        public async Task<(bool Resultado, string Mensaje, List<SongModel> items)> GetListSongs()
        {
            try
            {
                var result = await this._songRepository.GetAll();
                if (result.Resultado)
                {
                    return (true, "Se recupero listado de Songs:", SongsMapper.map(result.items));
                }
                else
                {
                    return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Obtener el listado de Songs: Messaje :"+ex.Message+" | "+ex.InnerException, null);
            }
        }
        public async Task<(bool Resultado, string Mensaje, SongModel item)> AddNewSong(SongModel song)
        {
            try
            {
                if(song != null)
                {
                    var val = SongsMapper.map(song);
                    var result = await this._songRepository.Insert(val);
                    if (result.Resultado)
                    {
                        return (true, "El song se creo exitosamente", SongsMapper.map(result.item));
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
                return (false, "Error al Crear un Songs: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        #endregion
        #region Metodos Privados

        #endregion
    }
}
