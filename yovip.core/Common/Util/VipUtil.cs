

namespace VIP.Core
{
    using VIP.Core.Models;
    public static class VipUtil
    {
        public static IMiniprogram Miniprogram = new Miniprogram("wx6647cb456db305dd", "c87dc3870c226091f0778c3d0544147a");
        public static string WeChatAuthUrl = "https://api.weixin.qq.com/sns/jscode2session?appid={0}&js_code={1}&secret={2}&grant_type=authorization_code";     
    }
}
