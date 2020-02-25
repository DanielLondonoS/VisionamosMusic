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
    public class AuthorController : Controller
    {
        #region Propiedades
        private readonly IAuthorService _authorService;
        #endregion
        #region Constructor
        public AuthorController(IAuthorService authorService)
        {
            this._authorService = authorService;
        }
        #endregion
        #region Metodos Publicos
        [HttpGet]
        [Route("listadoAutores")]
        public async Task<ActionResult> ListadoDeAutores()
        {
            try
            {
                var resultado = await this._authorService.GetListAuthor();
                if (resultado.Resultado)
                {
                    return new JsonResult(new AuthorApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Author = null,
                        ListAuthors = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new AuthorApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Author = null,
                        ListAuthors = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new AuthorApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Author = null,
                    ListAuthors = null
                });
            }

        }
        [HttpPost]
        [Route("agregarAutor")]
        public async Task<ActionResult> AgregarAuthor([FromBody] AuthorModel model)
        {
            try
            {
                var resultado = await this._authorService.AddNewAuthor(model);
                if (resultado.Resultado)
                {
                    return new JsonResult(new AuthorApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Author = resultado.item,
                        ListAuthors = null
                    });
                }
                else
                {
                    return new JsonResult(new AuthorApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Author = null,
                        ListAuthors = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new AuthorApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Author = null,
                    ListAuthors = null
                });
            }
        }
        #endregion
        #region Metodos Privados

        #endregion
    }


}
