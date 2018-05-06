
namespace YoVip.Portal.Api.Controllers
{
    using System;
    using System.Web.Http;
    using YoVip.Core;
    using YoVip.Core.Models;
    using YoVip.Core.Services;
    using Org.Joey.Common;

    public class YoShareController : System.Web.Http.ApiController
    {
        //获取成功设置小程序全局session
        //https://api.weixin.qq.com/sns/jscode2session?appid=APPID&secret=SECRET&js_code=JSCODE&grant_type=authorization_code
        private readonly WxSessionService service = new WxSessionService();
        [Route("api/yovip/DecodeUserInfo")]
        [HttpGet]
        public WxSession DecodeUserInfo(string code, string iv, string encryptedData, string signature)
        {
            var session = service.CreateWxSession(new WeChatLoginUser(code, iv, encryptedData, signature));
            return session;
        }


        [Route("api/yovip/GetAuth")]
        [HttpGet]
        public IWxAuthorization GetAuth(string code, string iv)
        {
            return service.GetWxAuth(new WeChatLoginUser(code, iv, null, null));
        }

        [Route("api/yovip/GetAccessToken")]
        public void GetAccessToken(string appid, string secret)
        {
            var token = service.GetWxAccessToken(appid, secret);
            var result = WxApiService.CreateTestwhiteList(token.Token, new string[] { "s66822351", "ebyinglw", "lily-liu2017" });
            WxSubMerchant merchant = new WxSubMerchant()
            {
                Info = new WxSubMerchant.WxSubMerchantDetails()
                {
                    BrandName = "柠檬工坊",
                    //AppId = string.Empty,
                    LogoUrl = "http://mmbiz.xxxx",
                    EndTime = DateTime.Now.AddYears(1).ToUnixStampDateTime(),
                    Protocol = "mdasdfkl",
                    PrimaryCategoryId = 2,
                    SecondaryCategoryId = 2,
                }
            };
            var json = merchant.ToJson();
            var xxx = WxApiService.CreateSubMerchant(token.Token, merchant);
            //var response = service.CreatedCard(token.Token);
            //var code = service.CreateWxQRCode(token.Token, response.CardId);
            //return code;
        }
        [Route("api/yovip/Test")]
        [HttpGet]
        public string Test()
        {
            return "ok";
        }
    }
}
