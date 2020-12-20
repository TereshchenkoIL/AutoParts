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
    class Brake_Disk : IAnalog
    {
        public int id { get; set; }
        
        public double ExDleiametr { get; set; }
        public double CDiametr { get; set; }
        public double MinThin { get; set; }
        public double Thin { get; set; } 
        public string Name { get; set; }
        public string Car { get; set; }

        //public Brake_Disk(int _id, double _dc, double _ed, double _mt, double _t, string name)
        //{
        //    id = _id;
            
        //    ExDleiametr = _ed;
        //    CDiametr = _dc;
        //    MinThin = _mt;
        //    Thin = _t;
        //    Name = name;
        //}
        public Brake_Disk(int _id, string _dc, string _ed, string _mt, string _t, string name, string car)
        {
            id = _id;
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            
            
            ExDleiametr =double.Parse( _ed.Trim());
            CDiametr = double.Parse(_dc);
            MinThin = double.Parse(_mt);
            Thin = double.Parse(_t);
            Thread.CurrentThread.CurrentCulture = temp_culture;
            Name = name;
            Car = car;
        }

        public bool HasAnalog(IAnalog item)
        {
            Brake_Disk br = (Brake_Disk)item;
            if (ExDleiametr == br.ExDleiametr && (br.CDiametr >= CDiametr - 1 || br.CDiametr <= CDiametr + 1) && (br.Thin >= MinThin || br.Thin <= Thin + 2))
                return true;
            return false;
        }

        
    }
}
