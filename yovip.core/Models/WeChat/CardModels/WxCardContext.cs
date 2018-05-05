

namespace YoVip.Core.Models
{
    using System;
    public abstract class WxCardContext<T> where T : WxBaseCard
    {

        [Newtonsoft.Json.JsonProperty("card_type")]
        public virtual string CardType { get; set; }
        public virtual T Card
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
    public class CashCardWxCardContext : WxCardContext<CashWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("cash")]
        public override CashWxBaseCard Card { get; set; }
    }
    public class DiscountWxCardContext : WxCardContext<DiscountWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("discount")]
        public override DiscountWxBaseCard Card { get; set; }
    }
    public class GeneralCouponWxCardContext : WxCardContext<GeneralCouponWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("general_coupon")]
        public override GeneralCouponWxBaseCard Card { get; set; }
    }
    public class GiftWxCardContext : WxCardContext<GiftWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("gift")]
        public override GiftWxBaseCard Card { get; set; }
    }
    public class GrouponWxCardContext : WxCardContext<GrouponWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("groupon")]
        public override GrouponWxBaseCard Card { get; set; }
    }
    public class MemberWxCardContext : WxCardContext<MemberWxBaseCard>
    {
        [Newtonsoft.Json.JsonProperty("member_card")]
        public override MemberWxBaseCard Card { get; set; }
    }
}
