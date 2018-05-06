
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace YoVip.Core.Services
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using Org.Joey.Common;
    using System.Security.Cryptography;
    using YoVip.Core;
    using YoVip.Core.Models;
    using System.IO;
    using System.Net;

    public class WxSessionService : IWxSessionService
    {
        //https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1451025062

        public WxSession CreateWxSession(IWxLoginUser loginUser)
        {
            IMiniprogram program = WxUtil.Miniprogram;
            var request = WxUtil.GenerateWxAuthRequestUrl(program.AppId, loginUser.Code, program.AppSecrect);

            var auth = request.GetResponseForJson<WeChatAuthorization>();
            var wechatUser = Decrypt(loginUser.Data, loginUser.IV, auth.SessionKey);
            return new WxSession() { LoginUser = loginUser, Miniprogram = program, WeCharUser = wechatUser, Authorization = auth };
        }
        public IWxAuthorization GetWxAuth(IWxLoginUser loginUser)
        {
            IMiniprogram program = WxUtil.Miniprogram;
            var request = WxUtil.GenerateWxAuthRequestUrl(program.AppId, loginUser.Code, program.AppSecrect);
            var auth = request.GetResponseForJson<WeChatAuthorization>();
            return auth;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData">公开的用户资料</param>
        /// <param name="signature"></param>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        private bool VaildateSignature(string rawData, string signature, string sessionKey)
        {
            //创建SHA1签名类  
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            //编码用于SHA1验证的源数据  
            byte[] source = Encoding.UTF8.GetBytes(rawData + sessionKey);
            //生成签名  
            byte[] target = sha1.ComputeHash(source);
            //转化为string类型，注意此处转化后是中间带短横杠的大写字母，需要剔除横杠转小写字母  
            string result = BitConverter.ToString(target).Replace("-", "").ToLower();
            //比对，输出验证结果  
            return signature == result;
        }
        private WxUser Decrypt(string encryptedData, string iv, string sessionKey)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
#pragma warning restore IDE0017 // Simplify object initialization
            //设置解密器参数  
            aes.Mode = CipherMode.CBC;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            //格式化待处理字符串  
            byte[] byte_encryptedData = Convert.FromBase64String(encryptedData);
            byte[] byte_iv = Convert.FromBase64String(iv);
            byte[] byte_sessionKey = Convert.FromBase64String(sessionKey);

            aes.IV = byte_iv;
            aes.Key = byte_sessionKey;
            //根据设置好的数据生成解密器实例  
            ICryptoTransform transform = aes.CreateDecryptor();

            //解密  
            byte[] final = transform.TransformFinalBlock(byte_encryptedData, 0, byte_encryptedData.Length);

            //生成结果  
            string result = Encoding.UTF8.GetString(final);

            //反序列化结果，生成用户信息实例  
            return result.DeserializeToObject<WxUser>();
        }
        public string GetOpenId(IWxLoginUser loginUser)
        {
            return this.CreateWxSession(loginUser).WeCharUser.OpenId;
        }
        public IWxAccessToken GetWxAccessToken(string appid, string secret)
        {
            var request = WxUtil.GenerateWxTokenRequestUrl(appid, secret);
            return request.GetResponseForJson<WxAccessToken>();
        }
        public CreateCardWxResponse CreatedCard(string token)
        {
            var wapper = File.ReadAllText(@"D:\Workspaces\yovip\portals\yovip.api\bin\Models\WeChat\CardModels\Templates\member_card.json")
                .DeserializeToObject<WxCardWapper<MemberWxCardContext, MemberWxBaseCard>>();

            return WxApiService.Create(token, wapper);
        }
        public void PostLogImage(string token)
        {
            var request = WxUtil.GenerateWxUploaMediaUrl(token, WxMediaTypes.Image);
            var context = request.GetResponse((http) =>
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
                        @"yovip.jpg"));
                byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());

                FileStream fs = new FileStream(@"D:\Workspaces\yovip\portals\yovip.api\Content\images\yovip.jpg", FileMode.Open, FileAccess.Read);
                byte[] bArr = new byte[fs.Length];
                fs.Read(bArr, 0, bArr.Length);
                fs.Close();

                using (Stream postStream = http.GetRequestStream())
                {
                    postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                    postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
                    postStream.Write(bArr, 0, bArr.Length);
                    postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
                    postStream.Flush();
                }
                return http;
            });
        }

        public QRCodeWxResponse CreateWxQRCode(string token, string cardid)
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
            //{ "errcode":0,"errmsg":"ok","ticket":"gQGX7zwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyMkZNbVVqeHlkb2oxU1dfRWhxNGwAAgSyeOhaAwQIBwAA","expire_seconds":1800,"url":"http:\/\/weixin.qq.com\/q\/022FMmUjxydoj1SW_Ehq4l","show_qrcode_url":"https:\/\/mp.weixin.qq.com\/cgi-bin\/showqrcode?ticket=gQGX7zwAAAAAAAAAAS5odHRwOi8vd2VpeGluLnFxLmNvbS9xLzAyMkZNbVVqeHlkb2oxU1dfRWhxNGwAAgSyeOhaAwQIBwAA"}
            return qrcode;
        }

    }
}
