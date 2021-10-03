using AutoParts.PartPickers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoParts.Model
{
    class PartPicker
    {
        private DBManager manager = new DBManager();
        private Picker picker;
        private SelectPartArgs _args;
        private PartPickerType _type;

        public int Type { 
            get => _type.GetTypeCode();
            set => _type = PartPickerType.NewType(value);
          
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

        private List<int> SelectBearings(SelectPartArgs selectPartArgs)
        {
            List<Bearing> direct = new List<Bearing>();
            List<Bearing> possible = new List<Bearing>();

            string sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id" +
                $" Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id WHERE p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Ширина','Діаметр','Зовнішній діаметр')" +
                $" AND p.Type_Id = {selectPartArgs.TypeId} " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value" +
                $" Order By p.Part_Id ASC, pr.Name ASC; ";
            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Bearing br = new Bearing(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                direct.Add(br);
            }

            sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id)" +
                $" INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id" +
                $" WHERE NOT p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Ширина','Діаметр','Зовнішній діаметр')" +
                $" AND p.Type_Id = 6" +
                $" GROUP BY p.Part_Id, PR.Name, OP.Value" +
                $" Order By p.Part_Id ASC, pr.Name ASC; ";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Bearing br = new Bearing(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }

        private List<int> SelectStabilizers(SelectPartArgs selectPartArgs)
        {
            List<Stabilizer> direct = new List<Stabilizer>();
            List<Stabilizer> possible = new List<Stabilizer>();

            string sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id)" +
                $" INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id " +
                $"WHERE p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Розміщення','Длина','Сторона')" +
                $" AND p.Type_Id = {selectPartArgs.TypeId}" +
                $" GROUP BY p.Part_Id, PR.Name, OP.Value " +
                $"Order By p.Part_Id ASC, pr.Name ASC; ";
            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Stabilizer br = new Stabilizer(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                direct.Add(br);
            }

            sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id" +
                $" Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id WHERE NOT p.Car_Id = {selectPartArgs.CarId} AND pr.Name IN('Розміщення','Длина','Сторона') AND p.Type_Id = 7" +
                $" GROUP BY p.Part_Id, PR.Name, OP.Value " +
                $"Order By p.Part_Id ASC, pr.Name ASC; ";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Stabilizer br = new Stabilizer(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());
            return picker.GetParts();
        }

        private List<int> SelectEItems(SelectPartArgs args)
        {
            List<EngineItem> direct = new List<EngineItem>();
            List<EngineItem> possible = new List<EngineItem>();

            string sql = $"Select p.Part_Id, m.Drive_type, e.Power, e.Volume, e.Type, c.Car_Id" +
                $" From Parts p INNER JOIN Cars c ON p.Car_Id = c.Car_Id " +
                $"INNER JOIN Modifications m ON m.Car_Id = c.Car_Id " +
                $"INNER JOIN Engines e ON e.Engine_Id = m.Engine_Id" +
                $" WHERE c.Car_Id = { args.CarId} AND p.Type_Id = { args.TypeId} AND e.Engine_Id = {args.EngineId} ";
            DataTable table = manager.Select(sql).Tables[0];
           foreach(DataRow row in table.Rows)
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
        public List<int> SelectOilFilters(SelectPartArgs args)
        {
            List<int> res = new List<int>();
            res.AddRange(SelectEItems(args));



            List<Bearing> direct = new List<Bearing>();
            List<Bearing> possible = new List<Bearing>();

            string sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id" +
                $" Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id " +
                $"WHERE p.Car_Id = {args.CarId} AND pr.Name IN('Висота','Діаметр','Зовнішній діаметр')" +
                $" AND p.Type_Id = {args.TypeId} " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value" +
                $" Order By p.Part_Id ASC, pr.Name ASC; ";
            DataTable table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Bearing br = new Bearing(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                direct.Add(br);
            }

            sql = $"SELECT p.Part_Id,   PR.Name, OP.Value " +
                $"FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) " +
                $"INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id " +
                $"Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id " +
                $"WHERE NOT p.Car_Id = { args.CarId} AND pr.Name IN('Висота','Діаметр','Зовнішній діаметр') " +
                $"AND p.Type_Id = 9 " +
                $"GROUP BY p.Part_Id, PR.Name, OP.Value " +
                $"Order By p.Part_Id ASC, pr.Name ASC; ";
            table = manager.Select(sql).Tables[0];
            for (int i = 0; i < table.Rows.Count; i += 3)
            {
                Bearing br = new Bearing(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"));
                possible.Add(br);
            }
            picker = new Picker(direct.OfType<IAnalog>().ToList(), possible.OfType<IAnalog>().ToList());

            res.AddRange(picker.GetParts());

            return res.Distinct().ToList(); ;
        }

        private List<int> SelectConsumables(SelectPartArgs selectPartArgs)
        {
            DataTable table = manager.Select("SELECT p.PART_iD" +
                " FROM PARTS p INNER JOIN Pr_Types pt ON P.Type_Id = pt.Type_Id " +
                $"WHERE pt.Type_Id = {selectPartArgs.TypeId}").Tables[0];

           return table.AsEnumerable().Select(x => (int)x["Part_Id"]).ToList(); 

        }

    
        public List<int> Pick(SelectPartArgs args)
        {
            switch (Type)
            {
                case PartPickerType.Locks:
                    return SelectLocks(args);                    
                case PartPickerType.Disks:
                    return SelectDisks(args);
                case PartPickerType.Battery:
                    return SelectBattery(args);
                case PartPickerType.Antifreeze:
                    return SelectConsumables(args);
                case PartPickerType.EngineOil:
                    return SelectConsumables(args);
                case PartPickerType.Bearings:
                    return SelectBearings(args);
                case PartPickerType.Stabilizers:
                    return SelectStabilizers(args);
                case PartPickerType.EItem:
                    if(args.EngineId == -1)
                    {
                        MessageBox.Show("Виберіть модифікацію");
                        return new List<int>();
                    }
                    return SelectEItems(args);
                case PartPickerType.OilFilter:
                    if (args.EngineId == -1)
                    {
                        MessageBox.Show("Виберіть модифікацію");
                        return new List<int>();
                    }
                    return SelectOilFilters(args);
                default:
                    return new List<int>();
              
            }
        }

        
    }
}
