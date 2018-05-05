﻿
namespace YoVip.Core.Models
{
    public class WxAdvancedInfo
    {
        [Newtonsoft.Json.JsonProperty("use_condition")]
        public virtual UseCondition UseCondition { get; set; }

        [Newtonsoft.Json.JsonProperty("abstract", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual WxAbstract Abstract { get; set; }


        [Newtonsoft.Json.JsonProperty("text_image_list", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual WxTextImage[] TextImageList { get; set; }


        [Newtonsoft.Json.JsonProperty("time_limit", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual WxTimeLimit[] TimeLimit { get; set; }


        [Newtonsoft.Json.JsonProperty("business_service", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual string[] BusinessService { get; set; }

    }
    public class UseCondition
    {
        [Newtonsoft.Json.JsonProperty("accept_category")]
        public virtual string AcceptCategory { get; set; }

        [Newtonsoft.Json.JsonProperty("reject_category")]
        public virtual string RejectCategory { get; set; }

        [Newtonsoft.Json.JsonProperty("can_use_with_other_discount")]
        public virtual bool CanUseWithOtherDiscount { get; set; }
        //"accept_category": "鞋类",
        // "reject_category": "阿迪达斯",
        // "can_use_with_other_discount": true
    }
}
