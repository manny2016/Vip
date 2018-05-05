using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    /// <summary>
    /// 微信会员卡
    /// </summary>
    public class MemberWxBaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("background_pic_url")]
        public virtual string BackgroundPicUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("supply_bonus")]
        public virtual bool SupplyBonus { get; set; }

        [Newtonsoft.Json.JsonProperty("supply_balance")]
        public virtual bool SupplyBalance { get; set; }

        [Newtonsoft.Json.JsonProperty("prerogative")]
        public virtual string Prerogative { get; set; }

        [Newtonsoft.Json.JsonProperty("auto_activate")]
        public virtual bool AutoActivate { get; set; }
        [Newtonsoft.Json.JsonProperty("custom_field1")]
        public virtual WxCustomField CustomFiled1 { get; set; }

        [Newtonsoft.Json.JsonProperty("activate_url")]
        public virtual string ActivateUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("bonus_rule")]
        public virtual WxBonusRule BonusRule { get; set; }

        [Newtonsoft.Json.JsonProperty("custom_cell1")]
        public virtual WxCustomCell CustomCell1 { get; set; }

        [Newtonsoft.Json.JsonProperty("discount")]
        public virtual decimal Discount { get; set; }
    }
}
