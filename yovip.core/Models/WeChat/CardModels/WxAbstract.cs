
namespace YoVip.Core.Models
{
    public class WxAbstract
    {
        [Newtonsoft.Json.JsonProperty("abstract")]
        public virtual string Abstract { get; set; }

        [Newtonsoft.Json.JsonProperty("icon_url_list")]
        public virtual string[] IcoUrlList { get; set; }
    }
}
