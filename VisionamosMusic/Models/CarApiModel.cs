using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class CarApiModel : BaseResponse
    {
        [JsonProperty(PropertyName = "car", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public CarModel Car { get; set; }
        [JsonProperty(PropertyName = "listCars", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<CarModel> ListCars { get; set; }
    }
}
