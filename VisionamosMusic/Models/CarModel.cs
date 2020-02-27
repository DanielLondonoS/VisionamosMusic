using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    /// <summary>
    /// Desarrollador: Daniel Londoño
    /// Fecha: 25/02/2020
    /// Descripcion: Entidad que se encarga del modelo de Car
    /// </summary>
    public class CarModel
    {
        /// <summary>
        /// Identificador del Carrito
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "song", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SongModel Song { get; set; }
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public UserModel User { get; set; }
        [JsonProperty(PropertyName = "date", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Date { get; set; }
    }
}
