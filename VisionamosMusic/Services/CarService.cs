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
    public class CarService : ICarService
    {
        #region Propiedades
        private readonly ICarRepository _carRepository;
        #endregion
        #region Constructor
        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
        #region
        #endregion Metodos Publicos
        public async Task<(bool Resultado, string Mensaje, List<CarModel> items)> GetListCars()
        {
            try
            {
                var result = await this._carRepository.GetAll();
                if (result.Resultado)
                {
                    return (true, "Se recupero listado de Cars:", CarsMapper.map(result.items));
                }
                else
                {
                    return (false, "Ocurrio un problema en el repositorio: RAZON:" + result.Mensaje, null);
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al Obtener el listado de Cars: Messaje :"+ex.Message+" | "+ex.InnerException, null);
            }
        }
        public async Task<(bool Resultado, string Mensaje, CarModel item)> AddNewCar(CarModel user)
        {
            try
            {
                if(user != null)
                {
                    var val = CarsMapper.map(user);
                    var result = await this._carRepository.Insert(val);
                    if (result.Resultado)
                    {
                        return (true, "El car se creo exitosamente", CarsMapper.map(result.item));
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
                return (false, "Error al Crear un Car: Messaje :" + ex.Message + " | " + ex.InnerException, null);
            }
        }
        #endregion
        #region Metodos Privados

        #endregion
    }
}
