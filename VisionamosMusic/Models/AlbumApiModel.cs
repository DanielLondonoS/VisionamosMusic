using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;

namespace VisionamosMusic.Models
{
    public class AlbumApiModel : BaseResponse
    {
        [JsonProperty(PropertyName = "album", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AlbumModel Album { get; set; }
        [JsonProperty(PropertyName = "listAlbumns", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<AlbumModel> ListAlbumns { get; set; }
    }
}
