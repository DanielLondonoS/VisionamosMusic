using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisionamosMusic.Models
{
    public class UserApiModel : BaseResponse
    {
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public UserModel User { get; set; }
        [JsonProperty(PropertyName = "listUsers", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<UserModel> ListUsers { get; set; }
    }
}
