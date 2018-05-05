using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public abstract class WxResponse
    {

        [Newtonsoft.Json.JsonProperty("errcode", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual int? ErrCode { get; set; }
        [Newtonsoft.Json.JsonProperty("errmsg", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual string ErrMsg { get; set; }
    }
    public  class NormalWxResponse : WxResponse
    {

    }
}
