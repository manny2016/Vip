using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class WxCardWapper<T> where T : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("card")]
        public T Card { get; set; }
    }
}
