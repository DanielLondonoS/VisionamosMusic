using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataRepositories.Interfaces
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Interface que se encarga de definir los metodos principales de una entidad
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    public interface IRepository<T> where T : class
    {
        Task<(bool Resultado, string Mensaje, List<T> items)> GetAll();
        Task<(bool Resultado, string Mensaje, T item)> GetById(int id);
        Task<(bool Resultado, string Mensaje)> Delete(int id);
        Task<(bool Resultado, string Mensaje, T item)> Update(int id, T element);
        Task<(bool Resultado, string Mensaje, T item)> Insert(T element);
    }

}
