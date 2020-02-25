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
    /// Descripcion: Entidad que se encarga del modelo de Songs
    /// </summary>
    public class SongModel
    {
        /// <summary>
        /// Identificador de la cancion
        /// </summary>
        [JsonProperty(PropertyName = "id",NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre de la cancion
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
        /// <summary>
        /// Autor de la cancion
        /// </summary>
        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AuthorModel Author { get; set; }
        /// <summary>
        /// Album al que pertenece la cancion
        /// </summary>
        [JsonProperty(PropertyName = "album", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AlbumModel Album { get; set; }
    }
}
