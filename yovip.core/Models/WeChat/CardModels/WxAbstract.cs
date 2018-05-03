using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxAbstract
    {
        [Newtonsoft.Json.JsonProperty("abstract")]
        public virtual string Abstract { get; set; }

        [Newtonsoft.Json.JsonProperty("icon_url_list")]
        public virtual string[] icon_url_list { get; set; }      
    }
}
