using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class Brake_Lock : IAnalog
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Thick { get; set; }
        public double Width { get; set; }
        public string Placement { get; set; }
        public Brake_Lock(int id, string h, string p, string t, string w )
        {
            this.Id = id;
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Height = double.Parse(h);
            Width = double.Parse(w);
            Thick = double.Parse(t);
            Placement = p;
            Thread.CurrentThread.CurrentCulture = temp_culture;
        }
        public bool HasAnalog(IAnalog item)
        {
            Brake_Lock o = (Brake_Lock)item;
            if (Placement == o.Placement && o.Height >= Height - 5 && o.Height <= Height + 5 && o.Width >= Width - 10 && o.Width <= Width + 10 && o.Thick >= Thick - 1.5 && o.Thick <= Thick - 1.5) return true;
            return false;
        }
    }
}
