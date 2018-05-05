using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public abstract class WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("base_info")]
        public virtual WxCardBaseInfo BaseInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("advanced_info")]
        public virtual WxAdvancedInfo AdvancedInfo { get; set; }
    }
}
