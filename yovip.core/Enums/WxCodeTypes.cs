using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Enums
{
    /// <summary>
    /// 码型
    /// </summary>
    public enum WxCodeTypes
    {
        //码型： "CODE_TYPE_TEXT"文 本 ； "CODE_TYPE_BARCODE"一维码 "CODE_TYPE_QRCODE"二维码 "CODE_TYPE_ONLY_QRCODE",二维码无code显示； "CODE_TYPE_ONLY_BARCODE",一维码无code显示；CODE_TYPE_NONE， 不显示code和条形码类型
        /// <summary>
        /// CODE_TYPE_NONE， 不显示code和条形码类型
        /// </summary>
        CODE_TYPE_NONE = 0,
        /// <summary>
        /// 文 本 ；
        /// </summary>
        CODE_TYPE_TEXT = 1,
        /// <summary>
        /// 一维码
        /// </summary>
        CODE_TYPE_BARCODE = 2,
        /// <summary>
        /// 二维码
        /// </summary>
        CODE_TYPE_QRCODE = 3,
        /// <summary>
        /// 二维码无code显示
        /// </summary>
        CODE_TYPE_ONLY_QRCODE = 4,
        /// <summary>
        /// 一维码 无code显示
        /// </summary>
        CODE_TYPE_ONLY_BARCODE = 5,

    }
}
