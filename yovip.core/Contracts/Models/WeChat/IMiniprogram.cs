using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIP.Core
{
    public interface IMiniprogram
    {
        string AppId { get; }
        string AppSecrect { get; }
    }
}
