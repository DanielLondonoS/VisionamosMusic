using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Models;
using VisionamosMusic.Services.Interfaces;

namespace VisionamosMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        #region Propiedades
        private readonly ISongService _songService;
        #endregion
        #region Constructor
        public SongController(ISongService songService)
        {
            this._songService = songService;
        }
        #endregion
        #region Metodos Publicos
        [HttpGet]
        [Route("listadoCanciones")]
        public async Task<ActionResult> ListadoDeCanciones()
        {
            try
            {
                var resultado = await this._songService.GetListSongs();
                if (resultado.Resultado)
                {
                    return new JsonResult(new SongApiModel
                    {
                        
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Song = null,
                        ListSongs = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new SongApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Song = null,
                        ListSongs = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new SongApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message+" | "+ex.InnerException,
                    Song = null,
                    ListSongs = null
                });
            }

        }
        [HttpPost]
        [Route("agregarCancion")]
        public async Task<ActionResult> AgregarCancion([FromBody] SongModel model)
        {
            try
            {                
                var resultado = await this._songService.AddNewSong(model);
                if (resultado.Resultado)
                {
                    return new JsonResult(new SongApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Song = resultado.item,
                        ListSongs = null
                    });
                }
                else
                {
                    return new JsonResult(new SongApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Song = null,
                        ListSongs = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new SongApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Song = null,
                    ListSongs = null
                });
            }

        }
        #endregion
        #region Metodos Privados

        #endregion

    }
}
