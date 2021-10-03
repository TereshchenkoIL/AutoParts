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
    class EngineItem : IAnalog
    {
        public int Id { get; set; }
        public string Drive_Type { get; set; }
        public int Power { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public EngineItem(DataRow row)
        {        
            this.Id = (int)row["Part_Id"];
            Drive_Type = (string)row["Drive_Type"];
            this.Power = (int)row["Power"];
            this.Volume = (double)row["Volume"];
            this.Type = (string)row["Type"];           
        }

        public virtual bool HasAnalog(IAnalog item)
        {
            EngineItem o = (EngineItem)item;
            if (Drive_Type == o.Drive_Type && o.Power >= Power - 40 
                && o.Power <= Power + 40 
                && o.Volume >= Volume - 0.5 
                && o.Volume <= Volume + 0.5 
                && o.Type == Type)
                return true;
            return false;
        }
    }
}
