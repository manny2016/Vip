using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxCardWapper<Context, BaseCard>
        where Context : WxCardContext<BaseCard>
        where BaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("card")]
        public Context Card { get; set; }
    }
}
