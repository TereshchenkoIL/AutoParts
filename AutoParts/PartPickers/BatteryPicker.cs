using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectBattery(args);
        }

        private List<int> SelectBattery(SelectPartArgs selectPartArgs)
        {
            List<Battery> direct = new List<Battery>();
            List<Battery> possible = new List<Battery>();

            string sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id" +
                $" WHERE p.Type_Id = {selectPartArgs.TypeId} AND p.Car_Id = { selectPartArgs.CarId} AND pr.Name IN('Ємність,Ач','Пусковий струм','') " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name,CONCAT(C.Mark, ' ', c.Model) " +
                $"Order By p.Part_Id ASC, pr.Name ASC; ";
            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 2)
            {
                Battery br = new Battery(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"));
                direct.Add(br);
            }
            sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
               $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
               $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id" +
               $" Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id " +
               $"WHERE  p.Type_Id = 3 AND NOT p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Ємність,Ач','Пусковий струм','') " +
               $"GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name,CONCAT(C.Mark, ' ', c.Model) " +
               $"Order By p.Part_Id ASC, pr.Name ASC; ";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 2)
            {
                Battery br = new Battery(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"));
                possible.Add(br);
            }

            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }
    }
}
