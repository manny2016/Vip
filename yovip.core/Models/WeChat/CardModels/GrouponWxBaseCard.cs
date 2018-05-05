

namespace YoVip.Core.Models
{
    public class GrouponWxBaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("deal_detail")]
        public virtual string DealDetail { get; set; }
    }
}
