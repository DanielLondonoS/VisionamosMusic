using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "isSuccess", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsSuccess { get; set; }
        [JsonProperty(PropertyName = "Message", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
