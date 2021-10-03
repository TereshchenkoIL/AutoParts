using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class Battery : IAnalog
    {
        public int Id { get ; set ; }
        public double Volume { get; set; }
        public double SCurrent { get; set; }

        public Battery(int id, string volume,string sc)
        {
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            this.Id = id;
            this.Volume = double.Parse( volume);
            this.SCurrent = double.Parse(sc);
            Thread.CurrentThread.CurrentCulture = temp_culture;
        }

        public bool HasAnalog(IAnalog item)
        {
            Battery o = (Battery)item;
            if (o.Volume >= Volume - 10 && o.Volume <= Volume + 10 && o.SCurrent >= SCurrent - 100 && o.SCurrent <= SCurrent + 100)
                return true;
            return false;
        }
    }
}
