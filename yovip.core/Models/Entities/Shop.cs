



namespace YoVip.Core.Models.Entities
{
    using YoVip.Core.Database;
    public class Shop : MySQLDataEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string License { get; set; }
        public virtual string Contact { get; set; }
        public virtual string ContactPhone { get; set; }
        public virtual string Coordinate { get; set; }
        public virtual string Address { get; set; }
        public virtual string Description { get; set; }
        public virtual string Addition { get; set; }
    }
}
