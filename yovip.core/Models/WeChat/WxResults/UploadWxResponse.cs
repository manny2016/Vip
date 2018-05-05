

namespace YoVip.Core.Models
{
    public class UploadWxResponse : WxResponse
    {
        [Newtonsoft.Json.JsonProperty("url")]
        public virtual string Url { get; set; }
    }
}
