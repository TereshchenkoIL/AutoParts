using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class OilFilter : IAnalog
    {
        public double Height { get; set; }
        public double InternalDiametr { get; set; }
        public double ExternalDIametr { get; set; }
        public int id { get; set ; }

        public OilFilter(int _id, double h, double d, double externalD) 
        {
            Height = h;
            InternalDiametr = d;
            ExternalDIametr = externalD;
            id = _id;
        }
        public  bool HasAnalog(IAnalog item)
        {
            OilFilter other = (OilFilter)item;

            if ((other.Height <= Height + 2 && other.Height >= Height - 2) && (other.InternalDiametr <= InternalDiametr + 3 && other.InternalDiametr >= InternalDiametr - 3) && (other.ExternalDIametr <= ExternalDIametr + 1 && other.ExternalDIametr >= ExternalDIametr - 1))
                return true;
            else
                return false;
        }
    }
}
