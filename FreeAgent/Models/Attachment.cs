using Newtonsoft.Json;
using System;

namespace FreeAgent.Models
{
    public class Attachment : BaseModel
    {
        [JsonProperty("content_src")]
        public Uri ContentSrc { get; set; }
        [JsonProperty("content_src_medium")]
        public Uri ContentSrcMedium { get; set; }
        [JsonProperty("content_src_small")]
        public Uri ContentSrcSmall { get; set; }
        [JsonProperty("content_type")]
        public string ContentType { get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        [JsonProperty("file_name")]
        public string FileName { get; set; }
        [JsonProperty("file_size")]
        public int FileSize { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public static class AttachmentContentType
    {
        public const string Png = "image/png";
        public const string XPng = "image/x-png";
        public const string Jpeg = "image/jpeg";
        public const string Jpg = "image/jpg";
        public const string Gif = "image/gif";
        public const string Pdf = "application/x-pdf";
    }
}



