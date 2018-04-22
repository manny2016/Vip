using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoVip.Core.Models
{
    public class Miniprogram : IMiniprogram
    {
        public Miniprogram(string appid, string appsecrect)
        {
            this.AppId = appid;
            this.AppSecrect = appsecrect;
        }

        public string AppId { get; private set; }

        public string AppSecrect { get; private set; }
    }
}
