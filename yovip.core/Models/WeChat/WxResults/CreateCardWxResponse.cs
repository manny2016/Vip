

namespace YoVip.Core.Models
{
    public class CreateCardWxResponse : WxResponse
    {
        [Newtonsoft.Json.JsonProperty("card_id")]
        public virtual string CardId { get; set; }
    }
}
