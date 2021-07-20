using Newtonsoft.Json;
using System;

namespace FreeAgent
{
    public class BaseModel
    {
        //public BaseModel()
        //{
        //    url = "";
        //}

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class UpdatableModel : BaseModel
    {
        //public UpdatableModel()
        //{
        //    updated_at = "";
        //    created_at = "";
        //}

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}

