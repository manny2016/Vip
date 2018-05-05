

namespace YoVip.Core.Models
{
    public class CashWxBaseCard : WxBaseCard
    {

        [Newtonsoft.Json.JsonProperty("least_cost")]
        public virtual decimal LeastCost { get; set; }

        [Newtonsoft.Json.JsonProperty("reduce_cost")]
        public virtual decimal ReduceCost { get; set; }        
    }
}
