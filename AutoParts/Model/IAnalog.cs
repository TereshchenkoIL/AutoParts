using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    interface IAnalog
    {
        int id { get; set; }
        bool HasAnalog(IAnalog item);
    }
}
