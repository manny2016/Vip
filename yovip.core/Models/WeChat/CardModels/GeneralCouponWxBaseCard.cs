﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class GeneralCouponWxBaseCard : WxBaseCard
    {
        [Newtonsoft.Json.JsonProperty("default_detail")]
        public virtual string DefaultDetail { get; set; }
    }
}
