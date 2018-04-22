


namespace YoVip.Core
{
    using YoVip.Core;
    using YoVip.Core.Models;

    public interface IWeChatSessionService
    {
        WeChatSession CreateWeChatSession(IWeChatLoginUser loginUseer);
        IWeChatAuthorization GetWeChatAuth(IWeChatLoginUser loginUser);
        string GetOpenId(IWeChatLoginUser loginUser);
    }
}
