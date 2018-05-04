

namespace YoVip.Core.Models
{
    using System;
    public abstract class WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("card_type")]
        public virtual string CardType { get; set; }

        public virtual WxBaseCard SpecificCard
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }

    public class CashWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("cash")]
        public override WxBaseCard SpecificCard { get; set; }
    }

    public class DiscountWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("discount")]
        public override WxBaseCard SpecificCard { get; set; }
    }
    public class GeneralCouponWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("general_coupon")]
        public override WxBaseCard SpecificCard { get; set; }
    }
    public class GiftWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("gift")]
        public override WxBaseCard SpecificCard { get; set; }
    }

    public class GrouponWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("groupon")]
        public override WxBaseCard SpecificCard { get; set; }
    }

    public class MemberWxCardContext : WxCardContext
    {
        [Newtonsoft.Json.JsonProperty("member_card")]
        public override WxBaseCard SpecificCard { get; set; }
    }
}
