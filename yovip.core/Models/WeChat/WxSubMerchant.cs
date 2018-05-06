

namespace YoVip.Core.Models
{
    /// <summary>
    ///info 是   json结构
    ///app_id 否 String(36)  wxxxxxxxxxxx 子商户的公众号app_id，配置后子商户卡券券面上的app_id为该app_id。注意：该app_id须经过认证
    ///brand_name  是 String(36)  兰州拉面 子商户名称（12个汉字内），该名称将在制券时填入并显示在卡券页面上
    ///logo_url    是 string (128)	http://mmbiz.xxxx	子商户logo，可通过 上传图片接口 获取。该logo将在制券时填入并显示在卡券页面上
    ///protocol 是   String(36)  mdasdfkl ：	授权函ID，即通过 上传临时素材接口 上传授权函后获得的meida_id
    ///end_time    是 unsigned int	15300000	授权函有效期截止时间（东八区时间，单位为秒），需要与提交的扫描件一致
    ///primary_category_id 是 int	2	一级类目id,可以通过本文档中接口查询
    ///secondary_category_id   是 int	2	二级类目id，可以通过本文档中接口查询
    ///agreement_media_id  否 string (36)	2343343424	营业执照或个体工商户营业执照彩照或扫描件
    ///operator_media_id   否 string (36)	2343343424	营业执照内登记的经营者身份证彩照或扫描件
    /// </summary>
    public class WxSubMerchant
    {

        [Newtonsoft.Json.JsonProperty("info", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public virtual WxSubMerchantDetails Info { get; set; }

   

        public class WxSubMerchantDetails
        {
            
            [Newtonsoft.Json.JsonProperty("brand_name")]
            public virtual string BrandName { get; set; }


            [Newtonsoft.Json.JsonProperty("merchant_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public virtual int? merchant_id { get; set; }

          

            [Newtonsoft.Json.JsonProperty("app_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public virtual string AppId { get; set; }

            [Newtonsoft.Json.JsonProperty("logo_url")]
            public virtual string LogoUrl { get; set; }

            /// <summary>
            /// 授权函ID，即通过 上传临时素材接口 上传授权函后获得的meida_id
            /// </summary>
            [Newtonsoft.Json.JsonProperty("protocol", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public virtual string Protocol { get; set; }
            /// <summary>
            /// 营业执照或个体工商户营业执照彩照或扫描件
            /// </summary>
            [Newtonsoft.Json.JsonProperty("agreement_media_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public virtual string AgreementMediaId { get; set; }
            /// <summary>
            /// 营业执照内登记的经营者身份证彩照或扫描件
            /// </summary>
            [Newtonsoft.Json.JsonProperty("operator_media_id")]
            public virtual string OperatorMediaId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("end_time")]
            public virtual long EndTime { get; set; }

            [Newtonsoft.Json.JsonProperty("primary_category_id", NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
            public virtual int PrimaryCategoryId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [Newtonsoft.Json.JsonProperty("secondary_category_id")]
            public virtual int SecondaryCategoryId { get; set; }

        }

    }
}
