using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxCustomField
    {
        [Newtonsoft.Json.JsonProperty("name_type")]
        public virtual string NameType { get; set; }

     
        [Newtonsoft.Json.JsonProperty("url")]
        public virtual string Url { get; set; }
      //"name_type": "FIELD_NAME_TYPE_LEVEL",
      //  "url": "http://www.qq.com"

    }
}
