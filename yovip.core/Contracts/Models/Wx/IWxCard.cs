using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core
{
    public interface IWxCard
    {
        void Set(string path, object value);
        T Get<T>(string path);
    }
}
