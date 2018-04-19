using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP.Core.Models
{
    public class WeChatSession
    {
        public IMiniprogram Miniprogram { get; set; }
        public IWeChatAuthorization Authorization { get; set; }
        public IWeChatLoginUser LoginUser { get; set; }

        public WeChatUser WeCharUser { get; set; }
    }
}
