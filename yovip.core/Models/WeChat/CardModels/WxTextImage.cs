

namespace YoVip.Core.Models
{
    public class WxTextImage
    {
        [Newtonsoft.Json.JsonProperty("image_url")]
        public virtual string ImageUrl { get; set; }
        [Newtonsoft.Json.JsonProperty("text")]
        public virtual string Text { get; set; }

    }
}
