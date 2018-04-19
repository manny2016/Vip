


namespace VIP.Core
{
    using VIP.Core.Models;
    public interface IWeChatSessionService
    {
        WeChatSession CreateWeChatSession(IWeChatLoginUser loginUseer);
        IWeChatAuthorization GetWeChatAuth(IWeChatLoginUser loginUser);
        string GetOpenId(IWeChatLoginUser loginUser);
    }
}
