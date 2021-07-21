using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public class BaseModel
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class UpdatableModel : BaseModel
    {
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}

