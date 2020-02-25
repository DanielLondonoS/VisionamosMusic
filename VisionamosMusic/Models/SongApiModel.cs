using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class SongApiModel : BaseResponse
    {
        [JsonProperty(PropertyName = "song", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public SongModel Song { get; set; }
        [JsonProperty(PropertyName = "listSongs", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<SongModel> ListSongs { get; set; }
    }
}
