using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxCustomCell
    {
        [Newtonsoft.Json.JsonProperty("name")]
        public virtual string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("tips")]
        public virtual string Tips { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public virtual string Url { get; set; }
        // "name": "使用入口2",
        //"tips": "激活后显示",
        //"url": "http://www.xxx.com"
    }
}
