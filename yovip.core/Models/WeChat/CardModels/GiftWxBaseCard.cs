using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class GiftWxBaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("gift")]
        public virtual string Gift { get; set; }
    }
}
