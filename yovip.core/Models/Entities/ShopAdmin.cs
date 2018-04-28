
namespace YoVip.Core.Models.Entities
{
    using YoVip.Core.Database;
    public class ShopAdmin : MySQLDataEntity
    {
        public virtual long ShopId { get; set; }

        public virtual long MemberId { get; set; }
    }
}
