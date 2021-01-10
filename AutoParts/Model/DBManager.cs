using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AutoParts.Model
{
    class DBManager
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString;

        public DataSet GetUserInformation(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT * FROM Users WHERE USER_ID = {Id}";
                SqlDataAdapter adapter = new SqlDataAdapter(sql,connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }

        }
        public DataSet GetUserOrderDetails(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT o.Order_Id, o.Create_Date, SUM(p.Price*op.Quantity) AS Total " +
                    $"FROM Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id " +
                    $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                    $"WHERE o.User_Id = { Id} " +
                    $"Group By o.Order_Id, o.Create_Date";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }
        public void UpdateUser(DataRow user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar, 90));
                command.Parameters.Add(new SqlParameter("@second", SqlDbType.NVarChar, 70));
                command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 100));
                command.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 100));
                command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 25));
                command.Parameters.Add(new SqlParameter("@adress", SqlDbType.NVarChar, 25));
                command.Parameters.Add(new SqlParameter("@disc", SqlDbType.Int, 0));
                command.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Bit, 0));
                command.Parameters.Add("@Id", SqlDbType.Int, 0, "User_Id");

                command.Parameters["@name"].Value = user["Name"];
                command.Parameters["@surname"].Value = user["Surname"];
                command.Parameters["@second"].Value = user["Second_name"];
                command.Parameters["@email"].Value = user["Email"];
                command.Parameters["@phone"].Value = user["Phone"];
                command.Parameters["@username"].Value = user["UserName"];
                command.Parameters["@password"].Value = user["Password"];
                command.Parameters["@city"].Value = user["City"];
                command.Parameters["@disc"].Value = DBNull.Value;
                command.Parameters["@isAdmin"].Value = false;
                command.Parameters["@adress"].Value = user["Adress"];
                command.Parameters["@Id"].Value = user["User_Id"];
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public DataSet GetOrderInformation(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT u.Name, u.Second_name, u.Surname, o.Order_Id, o.Create_Date, o.Create_Time, o.Curr " +
                    $"FROM USERS u " +
                    $"INNER JOIN ORDERS o ON u.User_Id = O.User_Id" +
                    $" Where o.Order_Id = {id}";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        public DataSet GetPartInOrder(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"SELECT p.Name,op.Quantity, p.Price " +
                    $"FROM Orders o " +
                    $"INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id " +
                    $"INNER JOIN Parts p ON op.Part_Id = P.Part_Id" +
                    $" WHERE o.Order_Id = {id}";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        public DataSet GetTypes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * FROM Pr_Types";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }
        public DataSet GetParts(int id = -1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT p.Part_Id, P.Name, P.Price,P.Producer_Name, pt.Name AS 'Тип', p.Warranty AS 'Гарантія', CONCAT(c.Mark, ' ' , c.Model, ' ', C.Year) AS Car,  COUNT(r.Response_Id) AS 'Кількість оцінок', AVG(R.Rate) AS 'Середня оцінка' " +
                    "FROM PARTS p INNER JOIN Pr_Types pt ON p.Type_Id = pT.Type_Id " +
                    "LEFT JOIN Responses r ON P.Part_Id = r.Part_Id " +
                    "LEFT JOIN Cars c ON P.Car_Id = c.Car_Id " +
                    "GROUP BY p.Part_Id, P.Name, P.Price,P.Producer_Name, p.Warranty,  pt.Name,CONCAT(c.Mark, ' ', c.Model, ' ', C.Year)";
                if(id != -1)
                    sql = $"Select * FROM Parts WHERE Part_Id = {id}";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        public DataSet Select(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();               
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }
        public async Task<DataSet> SelectAsync(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                await Task.Run(()=> adapter.Fill(ds));
                return ds;

            }
        }

        public DataSet GetProperties(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"Select p.Name,CONCAT(pp.value,p.Unit) As Значення  " +
                    $"From((Parts pr INNER JOIN Prop_Part pp ON(pr.Part_Id = pp.Part_Id AND pr.Part_Id = { id})) " +
                    $"INNER JOIN Properties p ON pp.Prop_Id = p.Prop_Id)";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;

            }
        }

        public void AddOrder(int user_id, Basket basket)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CreateOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 0, "User_Id"));
                command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date, 0, "Create_Date"));
                command.Parameters.Add(new SqlParameter("@time", SqlDbType.Time, 0, "Create_Time"));
                command.Parameters.Add(new SqlParameter("@curr", SqlDbType.VarChar, 1, "Curr"));
                SqlParameter parameter = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;
                command.Parameters["@user"].Value = user_id;
                command.Parameters["@date"].Value = DateTime.Now;
                command.Parameters["@time"].Value = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) ;
                command.Parameters["@curr"].Value = "$";
                command.ExecuteNonQuery();
                connection.Close();
                int order = (int)parameter.Value;

                foreach(var item in basket.Elements)
                {
                    connection.Open();
                    command = new SqlCommand("sp_CreateOP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@order", SqlDbType.Int, 0, "Order_Id"));
                    command.Parameters.Add(new SqlParameter("@part", SqlDbType.Int, 0, "Part_Id"));
                    command.Parameters.Add(new SqlParameter("@quant", SqlDbType.Int, 0, "Quantity"));
                    command.Parameters["@order"].Value = order;
                    command.Parameters["@part"].Value = item.Part_Id;
                    command.Parameters["@quant"].Value = item.Quantity;
                    command.ExecuteNonQuery();
                    connection.Close();
                    
                }
             

            }
        }

        public int AddRewiev(int user, int part, int mark, string text)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CreateReview", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@user_id", SqlDbType.Int, 0, "User_Id"));
                command.Parameters.Add(new SqlParameter("@part_id", SqlDbType.Int, 0, "Part_Id"));
                command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date, 0, "Create_Date"));
                command.Parameters.Add(new SqlParameter("@mark", SqlDbType.Int, 0, "Rate"));
                command.Parameters.Add(new SqlParameter("@text", SqlDbType.NVarChar, 500, "Text"));
                SqlParameter parameter = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;
                command.Parameters["@user_id"].Value = user;
                command.Parameters["@part_id"].Value = part;
                command.Parameters["@date"].Value = DateTime.Now;
                command.Parameters["@mark"].Value = mark;
                command.Parameters["@text"].Value = text;
                command.ExecuteNonQuery();
                connection.Close();
                return (int)parameter.Value;
            }
        }

        public DataSet GetReviews(int part)
        {
            string sql = $"SELECT CONCAT(u.Name,' ',u.Second_name,' ',u.Surname) AS Name, r.Response_Id, r.Part_Id,r.Create_Date,r.Rate,r.Text " +
                $"FROM Responses r INNER JOIN Users u ON r.User_Id = u.User_Id " +
                $"WHERE r.Part_Id = {part}";
            return Select(sql);
        }

        public DataSet GetCars()
        {
            string sql = "SELECT * FROM Cars";
            return Select(sql);
        }
        public DataSet GetModifications(int car_Id)
        {
            string sql = $"SELECT  Concat(e.Name, ' ', e.Power, ' лс ',e.Volume, ' л. ', e.Type) as ModName,e.Engine_Id, e.Power, e.Volume, e.Type, m.Drive_type" +
                $" From Modifications m " +
                $"INNER JOIN Engines e ON m.Engine_Id = e.Engine_Id " +
                $"Where m.Car_Id = {car_Id}";
            return Select(sql);
        }

        public int Create_User(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CreateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar, 90));
                command.Parameters.Add(new SqlParameter("@second", SqlDbType.NVarChar, 70));
                command.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 100));
                command.Parameters.Add(new SqlParameter("@phone", SqlDbType.NVarChar, 100));
                command.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar, 50));
                command.Parameters.Add(new SqlParameter("@city", SqlDbType.NVarChar, 25));
                command.Parameters.Add(new SqlParameter("@adress", SqlDbType.NVarChar, 25));
                command.Parameters.Add(new SqlParameter("@disc", SqlDbType.Int, 0));
                command.Parameters.Add(new SqlParameter("@isAdmin", SqlDbType.Bit, 0));
                SqlParameter parameter = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;
                command.Parameters["@name"].Value = user.Name;
                command.Parameters["@surname"].Value = user.Surname;
                command.Parameters["@second"].Value = user.Second_Name;
                command.Parameters["@email"].Value = user.Email;
                command.Parameters["@phone"].Value = user.Phone;
                command.Parameters["@username"].Value = user.UserName;
                command.Parameters["@password"].Value = user.Phone;
                command.Parameters["@city"].Value = " ";
                command.Parameters["@disc"].Value = DBNull.Value;
                command.Parameters["@isAdmin"].Value = false;
                command.Parameters["@adress"].Value = " ";
                command.ExecuteNonQuery();
                return (int)parameter.Value;
               
            }
        }

        public void Add_Producer(string name, string desc, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Producers (Producer_Name, Descript, Year)" +
                    $"Values ('{name}','{desc}', {year})";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Update_Producer(string name, string desc, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Update Producers SET " +
                    $"Descript = '{desc}', Year = {year}" +
                    $"WHERE Producer_Name = '{name}'";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Producer(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Producers " +                 
                    $"WHERE Producer_Name = '{name}'";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }

        public void Add_Car(string mark, string model,string type, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Cars (Mark, Model,Type, Year)" +
                    $"Values ('{mark}','{model}','{type}', {year})";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Update_Car(int car_id, string mark, string model, string type, int year)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Update Cars SET " +
                    $"Mark = '{mark}', Year = {year}," +
                    $"Model = '{model}', Type = '{type}'" +
                    $"WHERE Car_Id = {car_id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Car(int car_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Cars  " +
                    $"WHERE Car_Id = {car_id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }

        public DataSet GetModifications()
        {
            string sql = "SELECT m.Modif_Id,  m.NAME, M.Car_Id,m.Complect, M.Drive_type," +
                "CONCAT(e.Name,' ', e.Power, 'лс.  ', e.Volume, 'л. ') AS Engine," +
                " CONCAT(c.Mark,' ', c.Model, ' ',c.Year) AS Car " +
                "FROM Engines e INNER JOIN Modifications m ON e.Engine_Id = M.Engine_Id " +
                "INNER JOIN CARS c ON m.Car_Id = c.Car_Id; ";
            return Select(sql);
        }

        public void Add_Modification(string name, string complect, string type, int car_id, int engine_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Modifications (Name, Complect,Drive_Type, Car_Id, Engine_Id)" +
                    $"Values ('{name}','{complect}','{type}', {car_id}, {engine_id})";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Update_Modification(int id, string name, string complect, string type, int car_id, int engine_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Update Modifications SET " +
                    $"Name = '{name}', Complect = '{complect}'," +
                    $"Drive_type = '{type}', Car_Id = {car_id}," +
                    $"Engine_Id = {engine_id}" +
                    $"WHERE Modif_Id = {id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Modification(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Modifications  " +
                    $"WHERE Modif_Id = {id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }

        public void Add_Engine(string name, int power, double volume, string type)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Engines (Name, Power,Volume, Type)" +
                    $"Values ('{name}',{power},{volume}, '{type}')";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Update_Engine(int id, string name, int power, double volume, string type)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Update Engines SET " +
                    $"Name = '{name}', Power = {power}," +
                    $"Volume = {volume}, Type = '{type}'"+
                    $"WHERE Engine_Id = {id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Engine(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Engines  " +
                    $"WHERE Engine_Id = {id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }

        public void Add_Disc(string name, string desc, int disc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Discounts (Discount_Name, Descript,Disc)" +
                    $"Values ('{name}','{desc}',{disc})";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Update_Disc(string name, string desc, int disc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Update Discounts SET " +
                    $"Descript = '{desc}'," +
                    $"Disc = {disc}"+
                    $"WHERE Discount_Name = '{name}'";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Disc(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Discounts  " +
                    $"WHERE Discount_Name = '{name}'";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }

        public void Delete_Part_Prop(int prop_id, int part_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Prop_Part  " +
                    $"WHERE Prop_Id = {prop_id} AND Part_Id = {part_id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
        public void Delete_Order_Part(int order_id, int part_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Order_Part  " +
                    $"WHERE Order_Id = {order_id} AND Part_Id = {part_id}";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }

        }
    }
}
