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
    public class UserController : Controller
    {
        #region Propiedades
        private readonly IUserService _userService;
        #endregion
        #region Constructor
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        #endregion
        #region Metodos Publicos
        [HttpGet]
        [Route("listadoUsuarios")]
        public async Task<ActionResult> ListadoDeUsuarios()
        {
            try
            {
                var resultado = await this._userService.GetListUsers();
                if (resultado.Resultado)
                {
                    return new JsonResult(new UserApiModel
                    {
                        
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        User = null,
                        ListUsers = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new UserApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        User = null,
                        ListUsers = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new UserApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message+" | "+ex.InnerException,
                    User = null,
                    ListUsers = null
                });
            }

        }
        [HttpPost]
        [Route("agregarUsuario")]
        public async Task<ActionResult> AgregarUsuario([FromBody] UserModel model)
        {
            try
            {                
                var resultado = await this._userService.AddNewUser(model);
                if (resultado.Resultado)
                {
                    return new JsonResult(new UserApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        User = resultado.item,
                        ListUsers = null
                    });
                }
                else
                {
                    return new JsonResult(new UserApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        User = null,
                        ListUsers = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new UserApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    User = null,
                    ListUsers = null
                });
            }

        }
        #endregion
        #region Metodos Privados

        #endregion

    }
}
