

namespace YoVip.Core.Models
{

    using Newtonsoft.Json;
    using System.ComponentModel;

    public class WxCardBaseInfo
    {
        [Newtonsoft.Json.JsonProperty("logo_url")]
        public virtual string LogoUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("brand_name")]
        public virtual string BrandName { get; set; }

        [Newtonsoft.Json.JsonProperty("code_type")]
        public virtual string CodeType { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public virtual string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("color")]
        [DefaultValue("Color010")]
        public virtual string Color { get; set; }


        [Newtonsoft.Json.JsonProperty("notice")]
        [DefaultValue("使用时向服务员出示此券")]
        public virtual string Notice { get; set; }


        [Newtonsoft.Json.JsonProperty("service_phone")]
        public virtual string ServicePhone { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public virtual string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("date_info")]
        public virtual WxDateInfo Dateinfo { get; set; }


        [Newtonsoft.Json.JsonProperty("sku")]
        public virtual WxSku Sku { get; set; }



        [Newtonsoft.Json.JsonProperty("location_id_list")]
        public virtual decimal[] LocationIdList { get; set; }

        [Newtonsoft.Json.JsonProperty("use_limit")]
        [DefaultValue(1)]
        public virtual int Uselimit { get; set; }

        [Newtonsoft.Json.JsonProperty("get_limit")]
        [DefaultValue(1)]
        public virtual int Getlimit { get; set; }

        [Newtonsoft.Json.JsonProperty("use_custom_code")]
        public virtual bool UseCustomCode { get; set; }

        [Newtonsoft.Json.JsonProperty("bind_openid",NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? BindOpenid { get; set; }

        [Newtonsoft.Json.JsonProperty("can_share")]
        public virtual bool CanShare { get; set; }

        [Newtonsoft.Json.JsonProperty("can_give_friend")]
        public virtual bool CanGivefriend { get; set; }

        [Newtonsoft.Json.JsonProperty("center_title")]
        public virtual string CenterTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("center_sub_title")]
        public virtual string CenterSubTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("center_url")]
        public virtual string CenterUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_url_name")]
        public virtual string CustomUrlName { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_url")]
        public virtual string CustomUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_url_sub_title")]
        public virtual string CustomUrlSubTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("promotion_url_name")]
        public virtual string PromotionUrlName { get; set; }

        [Newtonsoft.Json.JsonProperty("promotion_url")]
        public virtual string PromotionUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("need_push_on_view", NullValueHandling = NullValueHandling.Ignore)]
        public virtual bool? NeedPushOnview { get; set; }

        [Newtonsoft.Json.JsonProperty("source")]
        public virtual string Source { get; set; }

        //        "base_info": {
        //  "logo_url": "http://mmbiz.qpic.cn/mmbiz/iaL1LJM1mF9aRKPZ/0",
        //  "brand_name": "海底捞",
        //  "code_type": "CODE_TYPE_TEXT",
        //  "title": "海底捞会员卡",
        //  "color": "Color010",
        //  "notice": "使用时向服务员出示此券",
        //  "service_phone": "020-88888888",
        //  "description": "不可与其他优惠同享",
        //  "date_info": {
        //    "type": "DATE_TYPE_PERMANENT"
        //  },
        //  "sku": {
        //    "quantity": 50000000
        //  },
        //  "get_limit": 3,
        //  "use_custom_code": false,
        //  "can_give_friend": true,
        //  "location_id_list": [
        //    123,
        //    12321
        //  ],
        //  "custom_url_name": "立即使用",
        //  "custom_url": "http://weixin.qq.com",
        //  "custom_url_sub_title": "6个汉字tips",
        //  "promotion_url_name": "营销入口1",
        //  "promotion_url": "http://www.qq.com",
        //  "need_push_on_view": true
        //},
    }
}
