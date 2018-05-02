using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core
{
    public static class DatabaseValueExtension
    {
        public static bool IsDBNull(this object obj)
        {
            if (obj == null) return false;
            return obj.GetType().Name.Equals("DBNull");
        }
    }
}
