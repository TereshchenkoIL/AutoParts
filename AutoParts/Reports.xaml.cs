using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FastReport;
using System.Data;
using System.Data.SqlClient;
using AutoParts.Model;
using System.Configuration;

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {

        FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        Report report = new Report();
        private DBManager manager = new DBManager();

        private static string connectionString = ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString;
        public Reports(bool order, int id)
        {
            InitializeComponent();

            if(order)
            {
                string sql = $"SELECT Concat(U.Name,' ',u.Second_name,' ',u.Surname) AS FIO, o.Order_Id, O.Create_Date, O.Create_Time, U.City, u.Adress, SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total " +
                    $"FROM((Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id) INNER JOIN Users u ON o.User_Id = u.User_Id" +
                    $" WHERE o.Order_Id = {id} " +
                    $"GROUP BY u.Name, u.Second_name, u.Surname,o.Order_Id, O.Create_Date, O.Create_Time, U.City, u.Adress";
                DataSet ds = new DataSet();
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds);

                report.Load(@"Reports/Check.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString; 
                report.RegisterData(ds);
                report.SetParameterValue("MyP", 1);

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
            else
            {
              

                if (id == -1)
                {
                    report.Load(@"Reports\AllPart.frx");
                    report.Dictionary.Connections[0].ConnectionString = connectionString;
                    report.Dictionary.Connections[1].ConnectionString = connectionString;

                    report.Preview = prew;
                    report.Prepare();
                    report.ShowPrepared();
                    WFHost.Child = prew;
                }
                else
                {


             
                    string sql = $"SELECT p.Part_Id,p.Name, p.Price, p.Descript,p.Price,p.Warranty, p.Producer_Name, " +
                        $"(SELECT t.Name FROM Pr_Types t WHERE t.Type_Id = p.Type_Id) AS Type" +
                        $" FROM Parts p Where p.Part_Id = {id} ";
                    DataSet ds = manager.Select(sql);
                    DataSet pr = manager.Select("Select pr.Name, pp.Value, pr.Unit, p.Part_Id " +
                        "FROM Parts p INNER JOIN Prop_Part pp ON p.Part_Id = pp.Part_Id " +
                        "INNER JOIN Properties pr ON pr.Prop_Id = pp.Prop_Id " +
                        $"WHERE p.Part_Id = {id} ");
                    DataTable tb = pr.Tables[0].Copy();
                    tb.TableName = "Table1";
                    ds.Tables.Add(tb);
                    report.Load(@"Reports\Part.frx");
                    report.Dictionary.Connections[0].ConnectionString = connectionString;
                    report.Dictionary.Connections[1].ConnectionString = connectionString;
                    report.RegisterData(ds);
                    report.RegisterData(ds, "Table");
                    report.RegisterData(pr, "Table1");
                    report.Preview = prew;
                    report.Prepare();
                    report.ShowPrepared();
                    WFHost.Child = prew;
                }
            }
        }

        public Reports(DateTime from, DateTime to, MyReportEnum type)
        {
            InitializeComponent();
            if(type == MyReportEnum.Profit)
            {
                string sql = $"SELECT COUNT(Orders) As 'Кількість заказів', SUM(Count_Parts) AS 'Кількість деталей', Sum(Total) AS 'Загальна сума' " +
                       $"FROM( " +
                       $"SELECT COUNT(o.Order_Id) AS Orders, SUM(op.Quantity) AS Count_Parts, SUM(op.Quantity * p.Price) AS Total " +
                       $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                       $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                       $"WHERE o.Create_Date BETWEEN '{from}'  AND  '{to}' " +
                       $"Group By o.Order_Id) Temp";
                DataSet ds = manager.Select(sql);
            report.Load(@"Reports/Profit.frx");
            report.Dictionary.Connections[0].ConnectionString = connectionString;      
            report.RegisterData(ds);
            report.SetParameterValue("From", from.ToString("MM/dd/yyyy"));
            report.SetParameterValue("To", to.ToString("MM/dd/yyyy"));

            report.Preview = prew;
            report.Prepare();
            report.ShowPrepared();
            WFHost.Child = prew;

            }
            else if (type == MyReportEnum.Sold_Parts)
            {
                string sql = $"SELECT  p.Part_Id, p.Name,p.Price, SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total,o.Create_Date " +
                        $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"WHERE o.Create_Date BETWEEN '{from}'  AND  '{to}'" +
                        $" GROUP BY p.Part_Id,p.Name,p.Price, o.Create_Date  ";
                DataSet ds = manager.Select(sql);
                report.Load(@"Reports/SoldParts.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString;
                report.RegisterData(ds);
                report.SetParameterValue("From", from.ToString("MM/dd/yyyy"));
                report.SetParameterValue("To", to.ToString("MM/dd/yyyy"));

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            } else if(type == MyReportEnum.ProfitPerMonth)
            {
                string sql = $"SELECT  Format(o.Create_Date,'MM-yy') As Date,  SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total " +
                        $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"Where o.Create_Date BETWEEN '{from}' " +
                        $" AND '{to}' " +
                        $" GROUP BY Format(o.Create_Date, 'MM-yy')";

                string sum = $"SELECT SUM(op.Quantity*p.Price) AS Total " +
                    $"FROM Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                    $"WHERE o.Create_Date BETWEEN '{from}'  AND  '{to}'";
                DataSet ds = manager.Select(sql);
                report.Load(@"Reports/ProfitPerMonth.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString;
                report.RegisterData(ds);
                report.SetParameterValue("From", from.ToString("MM/dd/yyyy"));
                report.SetParameterValue("To", to.ToString("MM/dd/yyyy"));
                report.SetParameterValue("TotalSum", ((decimal) manager.Select(sum).Tables[0].Rows[0]["Total"]).ToString());
                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
            else if (type == MyReportEnum.Types)
            {
                string sql = "SELECT t.Name, (CAST(COUNT(t.Name) AS DECIMAL(4, 2)) / CAST((SELECT COUNT(p2.PART_Id) FROM Parts p2) AS DECIMAL(4,2))*100) AS Perc" +
                        " FROM Parts p INNER JOIN Pr_Types t ON P.Type_Id = t.Type_Id " +
                        "GROUP BY t.Name";
                DataSet ds = manager.Select(sql);
                report.Load(@"Reports/Pr_Types.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString;
                report.RegisterData(ds);
             

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
            else if (type == MyReportEnum.AverageCheck)
            {
                string sql = "SELECT  Format(o.Create_Date,'MM-yy-dd') As Date, SUM(op.Quantity * p.Price)/SUM(op.Quantity) AS 'Середній  чек' " +
                        "FROM (Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        "INNER JOIN Parts p ON op.Part_Id = p.Part_Id  " +
                        $"Where o.Create_Date BETWEEN  '{from}' AND  '{to}' " +
                        "GROUP BY  Format(o.Create_Date,'MM-yy-dd')";
                DataSet ds = manager.Select(sql);
                report.Load(@"Reports/AverageCheck.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString;
                report.RegisterData(ds);
                report.SetParameterValue("From", from.ToString("MM/dd/yyyy"));
                report.SetParameterValue("To", to.ToString("MM/dd/yyyy"));

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
            else if (type == MyReportEnum.ProfitPerDay)
            {
                string sql = $"SELECT  Format(o.Create_Date,'MM-yy-dd') As Date, SUM(op.Quantity * p.Price) AS Total " +
                        "FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id)" +
                        "  INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $" WHERE o.Create_Date BETWEEN '{from}'  " +
                        $"AND  '{to}'  " +
                        $"Group By  Format(o.Create_Date,'MM-yy-dd')";

                string sum = $"SELECT SUM(op.Quantity*p.Price) AS Total " +
                    $"FROM Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                    $"WHERE o.Create_Date BETWEEN '{from}'  AND  '{to}'";
                DataSet ds = manager.Select(sql);
                report.Load(@"Reports/ProfitPerDay.frx");
                report.Dictionary.Connections[0].ConnectionString = connectionString;
                report.RegisterData(ds);
                report.SetParameterValue("From", from.ToString("MM/dd/yyyy"));
                report.SetParameterValue("To", to.ToString("MM/dd/yyyy"));
                report.SetParameterValue("TotalSum", ((decimal)manager.Select(sum).Tables[0].Rows[0]["Total"]).ToString());
                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
          
        }
    }

}
