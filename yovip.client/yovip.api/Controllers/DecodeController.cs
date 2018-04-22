using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIP.Core;
using VIP.Core.Models;

namespace VIP.Api.Controllers
{
    public class DecodeController : ApiController
    {
        //获取成功设置小程序全局session
        //https://api.weixin.qq.com/sns/jscode2session?appid=APPID&secret=SECRET&js_code=JSCODE&grant_type=authorization_code
        private readonly IWeChatSessionService service = new WeChatSessionService();
        [Route("api/wechat/DecodeUserInfo")]
        [HttpGet]
        public WeChatSession DecodeUserInfo(string code, string iv, string encryptedData, string signature)
        {
            var session = service.CreateWeChatSession(new WeChatLoginUser(code, iv, encryptedData, signature));
            return session;
        }
        [Route("api/wechat/GetAuth")]
        [HttpGet]
        public IWeChatAuthorization GetAuth(string code, string iv)
        {
            return service.GetWeChatAuth(new WeChatLoginUser(code, iv, null, null));
        }

    }
}
