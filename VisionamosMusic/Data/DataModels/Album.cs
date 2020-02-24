using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Data.DataModels
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 24/02/2020
    /// Descripcion: Entidad que se encarga de almacenar los albunes musicales
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Identificador del album
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nombre del album
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Fecha de pulicacion del album
        /// </summary>
        public DateTime PublishDate { get; set; }
    }
}
