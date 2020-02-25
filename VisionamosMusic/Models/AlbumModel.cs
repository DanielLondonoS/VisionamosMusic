using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class AlbumModel
    {
        /// <summary>
        /// Identificador del album
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del album
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
        /// <summary>
        /// Fecha de pulicacion del album
        /// </summary>
        [JsonProperty(PropertyName = "publishDate", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? PublishDate { get; set; }
        [JsonProperty(PropertyName = "autor", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AuthorModel Autor { get; set; }
    }
}
