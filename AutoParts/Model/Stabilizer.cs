using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class Stabilizer : IAnalog
    {
        public int id { get; set; }
        public double Length { get; set; }
        public string Placement { get; set; }
        public string Side { get; set; }
        public Stabilizer(int id, string l, string pl, string s)
        {
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            this.id = id;
            Length = double.Parse(l);
            Placement = pl;
            Side = s;
            Thread.CurrentThread.CurrentCulture = temp_culture;
        }

        public bool HasAnalog(IAnalog item)
        {
            Stabilizer o = (Stabilizer)item;

            if (o.Length >= Length - 10 && o.Length <= Length + 10 && o.Placement == Placement && (Side == "Двусторонній" || o.Side == "Двусторонній" || o.Side == Side))
                return true;
            return false;
            {

            }
        }
    }
}
