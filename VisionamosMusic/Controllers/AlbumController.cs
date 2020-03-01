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
    public class AlbumController : Controller
    {
        #region Propiedades
        private readonly IAlbumService _albumService;
        #endregion
        #region Constructor
        public AlbumController(IAlbumService albumService)
        {
            this._albumService = albumService;
        }
        #endregion
        #region Metodos Publicos
        [HttpGet]
        [Route("listadoAlbunes")]
        public async Task<ActionResult> ListadoDeAlbunes()
        {
            try
            {
                var resultado = await this._albumService.GetListAlbums();
                if (resultado.Resultado)
                {
                    return new JsonResult(new AlbumApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = null,
                        ListAlbumns = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new AlbumApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = null,
                        ListAlbumns = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new AlbumApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Album = null,
                    ListAlbumns = null
                });
            }

        }

        [HttpGet]
        [Route("listadoAlbunesPorAutor")]
        public async Task<ActionResult> ListadoDeAlbunesPorAutor(int id)
        {
            try
            {
                var resultado = await this._albumService.GetListAlbumsByAuthor(id);
                if (resultado.Resultado)
                {
                    return new JsonResult(new AlbumApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = null,
                        ListAlbumns = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new AlbumApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = null,
                        ListAlbumns = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new AlbumApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Album = null,
                    ListAlbumns = null
                });
            }

        }

        [HttpPost]
        [Route("agregarAlbum")]
        public async Task<ActionResult> AgregarAlbum([FromBody] AlbumModel model)
        {
            try
            {
                var resultado = await this._albumService.AddNewAlbum(model);
                if (resultado.Resultado)
                {
                    return new JsonResult(new AlbumApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = resultado.item,
                        ListAlbumns = null
                    });
                }
                else
                {
                    return new JsonResult(new AlbumApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Album = null,
                        ListAlbumns = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new AlbumApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Album = null,
                    ListAlbumns = null
                });
            }

        }
        #endregion
        #region Metodos Privados

        #endregion
    }
}
