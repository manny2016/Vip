
namespace YoVip.Core.Models
{
    public class DiscountWxBaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("discount")]
        public virtual decimal Discount { get; set; }
    }
}
