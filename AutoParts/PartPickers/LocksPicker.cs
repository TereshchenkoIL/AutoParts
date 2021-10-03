using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    class LocksPicker : PartPickerType
    {
        public override int GetTypeCode()
        {
            return Locks;
        }
        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectLocks(args);
        }
        private List<int> SelectLocks(SelectPartArgs selectPartArgs)
        {
            List<Brake_Lock> direct = new List<Brake_Lock>();
            List<Brake_Lock> possible = new List<Brake_Lock>();

            string sql = $"SELECT p.Part_Id,   PR.Name, OP.Value" +
                $" FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id" +
                $" WHERE p.Car_Id = { selectPartArgs.CarId} AND pr.Name IN('Висота','Ширина','Товщина','Розміщення') AND p.Type_Id = {selectPartArgs.TypeId} " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value " +
                $"Order By p.Part_Id ASC, pr.Name ASC;";
            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Lock br = new Brake_Lock(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"), table.Rows[i + 3].Field<string>("Value"));
                direct.Add(br);
            }

            sql = $"SELECT p.Part_Id,   PR.Name, OP.Value" +
                $" FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id" +
                $" Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id WHERE NOT p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Висота','Ширина','Товщина','Розміщення')" +
                $" AND p.Type_Id = 1 " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value" +
                $" Order By p.Part_Id ASC, pr.Name ASC;";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Lock br = new Brake_Lock(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"), table.Rows[i + 3].Field<string>("Value"));
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }
    }
}
