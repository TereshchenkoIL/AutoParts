using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    class BatteryPicker : PartPickerType
    {
        public override int GetTypeCode()
        {
            return Battery;
        }
    }
}
