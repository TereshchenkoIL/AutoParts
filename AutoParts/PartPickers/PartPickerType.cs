using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    abstract class PartPickerType
    {   public const int Locks = 1;
        public const int Disks = 2;
        public const int Battery = 3;
        public const int Antifreeze = 4;
        public const int EngineOil = 5;
        public const int Bearings = 6;
        public const int Stabilizers = 7;
        public const int EItem = 8;
        public const int OilFilter = 9;
        public abstract int GetTypeCode();

        public static PartPickerType NewType(int type)
        {
            switch (type)
            {
                case Locks:
                  return new LocksPicker();
                case Disks:
                    return new DisksPicker();
                case Battery:
                    return new BatteryPicker();
                case Antifreeze:
                    return new AntifreezePicker();
                case EngineOil:
                    return new EngineOilPicker();
                case Bearings:
                    return new BearingsPicker();
                case Stabilizers:
                    return new StabilizersPicker();
                case EItem:
                    return new EItemsPicker();
                case OilFilter:
                    return new OilFiltersPicker();
                default:
                    throw new ArgumentException("Incorrect PartPicker code");
            }
        }
      
    }
}
