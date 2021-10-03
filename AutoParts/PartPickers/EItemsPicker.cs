using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParts.PartPickers
{
    class EItemsPicker : PartPickerType
    {
        public override int GetTypeCode()
        {
            return EItem;
        }

        public override List<int> Pick(SelectPartArgs args)
        {
            return SelectEItems(args);
        }

        protected List<int> SelectEItems(SelectPartArgs args)
        {
            List<EngineItem> direct = new List<EngineItem>();
            List<EngineItem> possible = new List<EngineItem>();

            string sql = $"Select p.Part_Id, m.Drive_type, e.Power, e.Volume, e.Type, c.Car_Id" +
                $" From Parts p INNER JOIN Cars c ON p.Car_Id = c.Car_Id " +
                $"INNER JOIN Modifications m ON m.Car_Id = c.Car_Id " +
                $"INNER JOIN Engines e ON e.Engine_Id = m.Engine_Id" +
                $" WHERE c.Car_Id = { args.CarId} AND p.Type_Id = { args.TypeId} AND e.Engine_Id = {args.EngineId} ";
            DataTable table = manager.Select(sql).Tables[0];
            foreach (DataRow row in table.Rows)
            {
                EngineItem br = new EngineItem(row);
                direct.Add(br);
            }


            sql = $"Select p.Part_Id, m.Drive_type, e.Power, e.Volume, e.Type, c.Car_Id From Parts p " +
                $"INNER JOIN Cars c ON p.Car_Id = c.Car_Id " +
                $"INNER JOIN Modifications m ON m.Car_Id = c.Car_Id " +
                $"INNER JOIN Engines e ON e.Engine_Id = m.Engine_Id" +
                $" WHERE(c.Car_Id = { args.CarId} AND NOT e.Engine_Id = { args.EngineId} AND p.Type_Id = { args.TypeId} OR NOT c.Car_Id = { args.CarId} " +
                $"AND  e.Engine_Id = {args.EngineId}  AND p.Type_Id = { args.TypeId}) OR NOT c.Car_Id = { args.CarId} AND NOT e.Engine_Id = { args.EngineId} AND p.Type_Id = { args.TypeId} ";
            table = manager.Select(sql).Tables[0];
            foreach (DataRow row in table.Rows)
            {
                EngineItem br = new EngineItem(row);
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }
    }
}
