using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxSku
    {
        [Newtonsoft.Json.JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
