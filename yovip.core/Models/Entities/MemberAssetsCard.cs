
namespace YoVip.Core.Models.Entities
{
    using System;
    using YoVip.Core.Database;
    public class MemberAssetsCard : MySQLDataEntity
    {
        public virtual long Id { get; set; }
        public virtual long MemberId { get; set; }
        public virtual long ShopId { get; set; }
        public virtual long ShopAssetsId { get; set; }
        public virtual decimal? Banlace { get; set; }
        public virtual int? LoyaltyPoints { get; set; }
        public virtual long? Sharedfrom { get; set; }
        public virtual DateTime? CreatedTime { get; set; }
        public virtual DateTime? LastUsedTime { get; set; }
    }
}
