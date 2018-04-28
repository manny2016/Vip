



namespace YoVip.Core.Models.Entities
{
    using YoVip.Core.Database;
    public class ShopAssets : MySQLDataEntity
    {
        public virtual long Id { get; set; }
        public virtual int AssetType { get; set; }
        public virtual long ShopId { get; set; }
        public virtual string Name { get; set; }
        public virtual string ProfileUrl { get; set; }
        public virtual string Description { get; set; }
        public virtual string Settings { get; set; }
    }
}
