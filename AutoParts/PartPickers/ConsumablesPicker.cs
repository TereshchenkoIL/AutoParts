using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    abstract class ConsumablesPicker : PartPickerType
    {
        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectConsumables(args);
        }
        protected List<int> SelectConsumables(SelectPartArgs selectPartArgs)
        {
            DataTable table = manager.Select("SELECT p.PART_iD" +
                " FROM PARTS p INNER JOIN Pr_Types pt ON P.Type_Id = pt.Type_Id " +
                $"WHERE pt.Type_Id = {selectPartArgs.TypeId}").Tables[0];

            return table.AsEnumerable().Select(x => (int)x["Part_Id"]).ToList();

        }
    }
}
