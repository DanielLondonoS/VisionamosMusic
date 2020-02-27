using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Models;

namespace VisionamosMusic.Services.Interfaces
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Interface que se encarga de exponer los metodos publicos del servicio User
    /// </summary>
    public interface ICarService
    {
        Task<(bool Resultado, string Mensaje, List<CarModel> items)> GetListCars();
        Task<(bool Resultado, string Mensaje, CarModel item)> AddNewCar(CarModel song);
    }
}
