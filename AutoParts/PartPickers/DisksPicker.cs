using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    class DisksPicker : PartPickerType
    {
        public override int GetTypeCode()
        {
            return Disks;
        }

        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectDisks(args);
        }

        private List<int> SelectDisks(SelectPartArgs selectPartArgs)
        {
            List<Brake_Disk> direct = new List<Brake_Disk>();
            List<Brake_Disk> possible = new List<Brake_Disk>();

            string sql = $" SELECT p.Part_Id, p.Name,  PR.Name, OP.Value, CONCAT(C.Mark, ' ', c.Model) AS Car " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id" +
                $" WHERE p.Car_Id = { selectPartArgs.CarId} AND pr.Name IN('Зовнішній діаметр','Діаметр центрування', 'Товщина', 'Мінімальна товщина') " +
                $"AND p.Type_Id = {selectPartArgs.TypeId}  " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name,CONCAT(C.Mark, ' ', c.Model) " +
                $"Order By p.Part_Id ASC, pr.Name ASC";

            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Disk br = new Brake_Disk(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"), table.Rows[i + 3].Field<string>("Value"), table.Rows[i].Field<string>("Name"), table.Rows[i].Field<string>("Car"));
                direct.Add(br);
            }
            sql = $" SELECT p.Part_Id, p.Name,  PR.Name, OP.Value, CONCAT(C.Mark, ' ', c.Model) AS Car" +
                $" FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id)" +
                $" INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id " +
                $"WHERE NOT p.Car_Id = { selectPartArgs.CarId} AND pr.Name IN('Зовнішній діаметр','Діаметр центрування', 'Товщина', 'Мінімальна товщина')" +
                $" AND p.Type_Id = 2 " +
                $" GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name,CONCAT(C.Mark, ' ', c.Model) " +
                $"Order By p.Part_Id ASC, pr.Name ASC";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Disk br = new Brake_Disk(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"), table.Rows[i + 3].Field<string>("Value"), table.Rows[i].Field<string>("Name"), table.Rows[i].Field<string>("Car"));
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }
    }
}
