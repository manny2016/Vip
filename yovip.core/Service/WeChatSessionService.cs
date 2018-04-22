using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoVip.Core.Models;

namespace YoVip.Core
{
    using Newtonsoft.Json;
    using Org.Joey.Common;
    using System.Security.Cryptography;
    

    public class WeChatSessionService : IWeChatSessionService
    {

        public WeChatSession CreateWeChatSession(IWeChatLoginUser loginUseer)
        {
            IMiniprogram program = VipUtil.Miniprogram;
            var request = string.Format(VipUtil.WeChatAuthUrl, program.AppId, loginUseer.Code, program.AppSecrect);
            var auth = request.GetResponseForJson<WeChatAuthorization>();
            var wechatUser = Decrypt(loginUseer.Data, loginUseer.IV, auth.SessionKey);
            return new WeChatSession() { LoginUser = loginUseer, Miniprogram = program, WeCharUser = wechatUser, Authorization = auth };
        }
        public IWeChatAuthorization GetWeChatAuth(IWeChatLoginUser loginUser)
        {
            IMiniprogram program = VipUtil.Miniprogram;
            var request = string.Format(VipUtil.WeChatAuthUrl, program.AppId, loginUser.Code, program.AppSecrect);
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
        private WeChatUser Decrypt(string encryptedData, string iv, string sessionKey)
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
            return result.DeserializeToObject<WeChatUser>();
        }

        public string GetOpenId(IWeChatLoginUser loginUser)
        {
            return this.CreateWeChatSession(loginUser).WeCharUser.OpenId;
        }
    }
}
