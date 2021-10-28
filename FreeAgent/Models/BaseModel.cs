using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public abstract class BaseModel
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public abstract class UpdatableModel : BaseModel
    {
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public interface IAttachmentModel
    {
        Attachment Attachment { get; set; }
    }
}

