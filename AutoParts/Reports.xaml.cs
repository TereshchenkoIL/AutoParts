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

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        FastReport.Preview.PreviewControl prew = new FastReport.Preview.PreviewControl();
        Report report = new Report();
        public Reports(bool order, int id)
        {
            InitializeComponent();

            if(order)
            {
                string sql = $"SELECT Concat(U.Name,' ',u.Second_name,' ',u.Surname) AS FIO, o.Order_Id, O.Create_Date, O.Create_Time, U.City, u.Adress, SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total FROM((Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id) INNER JOIN Users u ON o.User_Id = u.User_Id WHERE o.Order_Id = {id} GROUP BY u.Name, u.Second_name, u.Surname,o.Order_Id, O.Create_Date, O.Create_Time, U.City, u.Adress";
                DataSet ds = new DataSet();
                SqlConnection connection = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=CourseWorkdb;Integrated Security=True");
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds);

                report.Load(@"D:\Check.frx");
                report.RegisterData(ds);
                report.SetParameterValue("MyP", 1);

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
            else
            {
                string sql = $"SELECT p.Part_Id,p.Name, p.Price, p.Descript,p.Price,p.Warranty, p.Producer_Name, (SELECT t.Name FROM Pr_Types t WHERE t.Type_Id = p.Type_Id) AS Type FROM Parts p ";
                DataSet ds = new DataSet();
                SqlConnection connection = new SqlConnection(@"Data Source=ASUS\SQLEXPRESS;Initial Catalog=CourseWorkdb;Integrated Security=True");
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds);

                report.Load(@"D:\Part.frx");
               // report.RegisterData(ds);
                

                report.Preview = prew;
                report.Prepare();
                report.ShowPrepared();
                WFHost.Child = prew;
            }
        }
    }
}
