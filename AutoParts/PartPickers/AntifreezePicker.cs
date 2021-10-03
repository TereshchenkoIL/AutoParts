using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    class AntifreezePicker : ConsumablesPicker
    {
        public override int GetTypeCode()
        {
            return Antifreeze;
        }

        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectConsumables(args);
        }
    }
}
