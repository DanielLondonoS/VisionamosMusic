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
    /// Descripcion: Entidad que se encarga del modelo de User
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Identificador del User
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "nombre", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Nombre { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Usuario { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "contrasena", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Contrasena { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "esAdmin", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string EsAdmin { get; set; }
    }
}
