using AutoParts.PartPickers;
using System.Collections.Generic;

namespace AutoParts.Model
{
    class PartPicker
    {
        private PartPickerType _type;
        public int Type { 
            get => _type.GetTypeCode();
            set => _type = PartPickerType.NewType(value);
          
        }
      
        public List<int> Pick(SelectPartArgs args)
        {
            return _type.Pick(args);
        }
      
    }
}
