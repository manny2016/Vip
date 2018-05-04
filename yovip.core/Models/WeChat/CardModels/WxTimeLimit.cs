

namespace YoVip.Core.Models
{
    public class WxTimeLimit
    {
        [Newtonsoft.Json.JsonProperty("type")]
        public virtual string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("begin_hour",NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual int? BeginHour { get; set; }

        [Newtonsoft.Json.JsonProperty("end_hour", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual int? EndHour { get; set; }

        [Newtonsoft.Json.JsonProperty("begin_minute", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual int? BeginMinute { get; set; }

        [Newtonsoft.Json.JsonProperty("end_minute", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual int? EndMinute { get; set; }        
    }
}
