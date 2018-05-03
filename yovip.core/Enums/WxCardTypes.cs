using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core
{
    public enum WxCardType
    {

        /// <summary>
        /// 团购优惠券
        /// </summary>
        GROUPON = 1,
        /// <summary>
        /// 代金券
        /// </summary>
        CASH = 2,
        /// <summary>
        /// 折扣券
        /// </summary>
        DISCOUNT = 3,
        /// <summary>
        /// 兑换券
        /// </summary>
        GIFT = 4,
        /// <summary>
        /// 优惠券
        /// </summary>
        GENERAL_COUPON = 5,
        /// <summary>
        /// 会员卡
        /// </summary>
        MEMBER_CARD = 6,

    }
}
