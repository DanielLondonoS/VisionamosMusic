using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class UserLoginModel
    {
        [JsonProperty(PropertyName = "usuario", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Usuario { get; set; }
        [JsonProperty(PropertyName = "contrasena", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Contrasena { get; set; }
    }
}
