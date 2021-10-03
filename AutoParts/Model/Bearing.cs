using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class Bearing : IAnalog
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Diametr { get; set; }
        public double ExDiametr { get; set; }

        public Bearing(int id, string d, string ex, string w)
        {
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            this.Id = id;
            Diametr = double.Parse(d);
            ExDiametr = double.Parse(ex);
            Width = double.Parse(w);
            Thread.CurrentThread.CurrentCulture = temp_culture;
        }


        public bool HasAnalog(IAnalog item)
        {
            Bearing o = (Bearing)item;

            if (o.Width >= Width - 1.5 && o.Width <= Width + 1.5 && o.ExDiametr >= ExDiametr - 10 && o.ExDiametr <= ExDiametr + 10 && o.Diametr >= Diametr - 5 && o.Diametr <= Diametr + 5)
                return true;
            return false;
        }
    }
}
