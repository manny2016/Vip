


namespace YoVip.Core.Services
{
    using System;
    using System.Text;
    using Org.Joey.Common;
    using System.Net;
    using System.IO;

    using YoVip.Core.Models;

    public class WxApiService
    {

        public static UploadWxResponse UploadImg(string token, string fileName)
        {
            Microsoft.Practices.EnterpriseLibrary.Common.Utility.Guard.ArgumentNotNull(token, "token");
            Microsoft.Practices.EnterpriseLibrary.Common.Utility.Guard.ArgumentNotNull(fileName, "fileName");

            var media = new FileInfo(fileName);
            if (media.Exists == false) throw new FileNotFoundException(fileName);

            var request = WxUtil.GenerateWxUploaMediaUrl(token, WxMediaTypes.Image);
            return request.GetResponseForJson<UploadWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/x-www-form-urlencoded";
                CookieContainer cookieContainer = new CookieContainer();
                http.CookieContainer = cookieContainer;
                http.AllowAutoRedirect = true;
                http.Method = "POST";
                string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
                http.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
                byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                StringBuilder sbHeader =
                new StringBuilder(
                    string.Format(
                        "Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n",
                        media.Name));
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
                using (var stream = media.OpenRead())
                {
                    byte[] bArr = new byte[stream.Length];
                    stream.Read(bArr, 0, bArr.Length);
                    using (Stream postStream = http.GetRequestStream())
                    {
                        postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                        postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                        postStream.Write(bArr, 0, bArr.Length);
                        postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                        postStream.Flush();
                    }
                }
                return http;
            });
            //return context.DeserializeToObject<UploadWxResponse>();
        }

        public static CreateCardWxResponse Create(string token, WxCardWapper<GiftWxCardContext, GiftWxBaseCard> wapper)
        {
            return Create<GiftWxCardContext, GiftWxBaseCard>(token, wapper);
        }

        public static CreateCardWxResponse Create(string token, WxCardWapper<MemberWxCardContext, MemberWxBaseCard> wapper)
        {
            return Create<MemberWxCardContext, MemberWxBaseCard>(token, wapper);
        }

        public static CreateCardWxResponse Create(string token, WxCardWapper<GrouponWxCardContext, GrouponWxBaseCard> wapper)
        {
            return Create<GrouponWxCardContext, GrouponWxBaseCard>(token, wapper);
        }
        public static CreateCardWxResponse Create(string token, WxCardWapper<GeneralCouponWxCardContext, GeneralCouponWxBaseCard> wapper)
        {
            return Create<GeneralCouponWxCardContext, GeneralCouponWxBaseCard>(token, wapper);
        }
        public static CreateCardWxResponse Create(string token, WxCardWapper<DiscountWxCardContext, DiscountWxBaseCard> wapper)
        {
            return Create<DiscountWxCardContext, DiscountWxBaseCard>(token, wapper);
        }
        public static CreateCardWxResponse Create(string token, WxCardWapper<CashCardWxCardContext, CashWxBaseCard> wapper)
        {
            return Create<CashCardWxCardContext, CashWxBaseCard>(token, wapper);
        }
        private static CreateCardWxResponse Create<CardContext, BaseCard>(string token, WxCardWapper<CardContext, BaseCard> wapper)
            where CardContext : WxCardContext<BaseCard>
            where BaseCard : WxBaseCard
        {
            var request = WxUtil.GenerateWxCreateCardUrl(token);
            return request.GetResponseForJson<CreateCardWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(wapper.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }
        /// <summary>
        /// 创建卡券之后，开发者可以通过设置微信买单接口设置该card_id支持微信买单功能。值得开发者注意的是，设置买单的card_id必须已经配置了门店，否则会报错。
        /// 设置买单接口
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cardid"></param>
        /// <param name="payable"></param>
        /// <returns></returns>
        public static NormalWxResponse Paycell(string token, string cardid, bool payable)
        {
            var request = WxUtil.GenrateWxPaycell(token);
            return request.GetResponseForJson<NormalWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new { card_id = cardid, is_open = payable };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }
        /// <summary>
        /// 设置自动核销
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cardid"></param>
        /// <param name="isOpen"></param>
        public static NormalWxResponse SelfConsumeCellSet(string token, string cardid, bool isOpen = true)
        {
            var request = WxUtil.GenerateWxSelfconsumecell(token);
            return request.GetResponseForJson<NormalWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new
                {
                    card_id = cardid,
                    is_open = isOpen,
                    need_verify_cod = false,
                    need_remark_amount = false
                };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }

        public static NormalWxResponse CreateTestwhiteList(string token,
            string[] usernams,
            string[] openids = null)
        {
            var request = WxUtil.GenerateWxtestwhitelist(token);
            return request.GetResponseForJson<NormalWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new
                {
                    openid = openids ?? new string[] { },
                    username = new string[] { "s66822351" }
                };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
        }

        public static QRCodeWxResponse CreateWxQRCode(string token, string cardid)
        {
            var request = WxUtil.GenerateWxQRCodeUrl(token);

            var qrcode = request.GetResponseForJson<QRCodeWxResponse>((http) =>
            {
                http.Method = "POST";
                http.ContentType = "application/json; encoding=utf-8";
                var data = new
                {
                    action_name = "QR_CARD",
                    expire_seconds = 1800,
                    action_info = new
                    {
                        card = new
                        {
                            card_id = cardid,
                            code = "",
                            openid = "",
                            is_unique_code = false,
                            outer_str = "13b",
                        }
                    }
                };
                using (var stream = http.GetRequestStream())
                {
                    var buffers = UTF8Encoding.UTF8.GetBytes(data.ToJson());
                    stream.Write(buffers, 0, buffers.Length);
                    stream.Flush();
                }
                return http;
            });
            return qrcode;
        }
        public static string CreateSubMerchant(string token, WxSubMerchant merchant)
        {
            var request = WxUtil.GenerateWxQRCodeUrl(token);

            return request.GetResponse((http) =>
             {
                 http.Method = "POST";
                 http.ContentType = "application/json; encoding=utf-8";
                 using (var stream = http.GetRequestStream())
                 {
                     var buffers = UTF8Encoding.UTF8.GetBytes(merchant.ToJson());
                     stream.Write(buffers, 0, buffers.Length);
                     stream.Flush();
                 }
                 return http;
             });
        }
    }
}
