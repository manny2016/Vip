


namespace YoVip.Core
{
    using YoVip.Core;
    using YoVip.Core.Models;

    public interface IWxSessionService
    {
        WxSession CreateWxSession(IWxLoginUser loginUseer);

        IWxAuthorization GetWxAuth(IWxLoginUser loginUser);

        string GetOpenId(IWxLoginUser loginUser);

        IWxAccessToken GetWxAccessToken(string appid, string secret);
    }
}
