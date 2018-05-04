
namespace YoVip.Core.Models
{
    using Newtonsoft.Json;
    public class WxDateInfo
    {
        [Newtonsoft.Json.JsonProperty("type")]
        public virtual string Type { get; set; }

        //in member card this property is ignore
        [Newtonsoft.Json.JsonProperty("begin_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? Start { get; set; }


        //in member card this property is ignore
        [Newtonsoft.Json.JsonProperty("end_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public virtual long? End { get; set; }
    }
}
