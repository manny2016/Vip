using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxDateInfo
    {
        [Newtonsoft.Json.JsonProperty("type")]
        public virtual string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("begin_timestamp")]
        public virtual long Start { get; set; }

        [Newtonsoft.Json.JsonProperty("end_timestamp")]
        public virtual long End { get; set; }
    }
}
