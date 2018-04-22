using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WeChatAuthorization : IWeChatAuthorization
    {
        [Newtonsoft.Json.JsonProperty("session_key")]
        public string SessionKey { get; set; }
        [Newtonsoft.Json.JsonProperty("openid")]
        public string OpenId { get; set; }
        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
