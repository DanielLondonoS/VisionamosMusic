using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisionamosMusic.Data.DataModels;

namespace VisionamosMusic.Models
{
    public class AuthorApiModel : BaseResponse
    {
        [JsonProperty(PropertyName = "author", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public AuthorModel Author { get; set; }
        [JsonProperty(PropertyName = "listAuthors", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<AuthorModel> ListAuthors { get; set; }
    }
}
