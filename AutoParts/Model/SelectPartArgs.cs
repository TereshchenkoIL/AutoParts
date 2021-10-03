using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.Model
{
    class SelectPartArgs
    {
        public int CarId { get; set; }
        public int TypeId { get; set; }
        public int EngineId { get; set; }
        public SelectPartArgs(int carId, int typeId, int engineId)
        {
            CarId = carId;
            TypeId = typeId;
            EngineId = engineId;
        }
    }
}
