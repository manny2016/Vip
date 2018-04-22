using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core
{
    public enum CardType
    {
        Nonne = 0,
        /// <summary>
        /// 积分卡（消费后积分）
        /// </summary>
        Scorecard,
        /// <summary>
        /// 预存金额
        /// </summary>
        ValueCard,
        /// <summary>
        /// 计次卡
        /// </summary>
        CountCard,

    }
}
