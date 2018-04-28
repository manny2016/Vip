﻿
using System;
using YoVip.Core.Database;

namespace YoVip.Core.Models.Entities
{
    public class Membership : MySQLDataEntity
    {
        public virtual long? Id { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string NickName { get; set; }
        public virtual int? Gender { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string Country { get; set; }
        public virtual string AvatarUrl { get; set; }
        public virtual int RegisteredSource { get; set; }
        public virtual string BindingWeChat { get; set; }
        public virtual string BindingAliPay { get; set; }
        public virtual DateTime? RegisteredTime { get; set; }
        public virtual DateTime? LastAccessTime { get; set; }

    }
}
