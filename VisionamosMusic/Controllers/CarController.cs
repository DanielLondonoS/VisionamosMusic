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
    public class CarController : Controller
    {
        #region Propiedades
        private readonly ICarService _carService;
        #endregion
        #region Constructor
        public CarController(ICarService carService)
        {
            this._carService = carService;
        }
        #endregion
        #region Metodos Publicos
        [HttpGet]
        [Route("listadoCarrito")]
        public async Task<ActionResult> ListadoDelCarrito()
        {
            try
            {
                var resultado = await this._carService.GetListCars();
                if (resultado.Resultado)
                {
                    return new JsonResult(new CarApiModel
                    {
                        
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Car = null,
                        ListCars = resultado.items
                    });
                }
                else
                {
                    return new JsonResult(new CarApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Car = null,
                        ListCars = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new CarApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message+" | "+ex.InnerException,
                    Car = null,
                    ListCars = null
                });
            }

        }
        [HttpPost]
        [Route("agregarCarrito")]
        public async Task<ActionResult> AgregarCarrito([FromBody] CarModel model)
        {
            try
            {                
                var resultado = await this._carService.AddNewCar(model);
                if (resultado.Resultado)
                {
                    return new JsonResult(new CarApiModel
                    {

                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Car = resultado.item,
                        ListCars = null
                    });
                }
                else
                {
                    return new JsonResult(new CarApiModel
                    {
                        IsSuccess = resultado.Resultado,
                        Message = resultado.Mensaje,
                        Car = null,
                        ListCars = null
                    });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new CarApiModel
                {
                    IsSuccess = false,
                    Message = ex.Message + " | " + ex.InnerException,
                    Car = null,
                    ListCars = null
                });
            }

        }
        #endregion
        #region Metodos Privados

        #endregion

    }
}
