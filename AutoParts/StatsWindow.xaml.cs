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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для SortsWindow.xaml
    /// </summary>
    public partial class SortsWindow : Window
    {
        private DataTable table;
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private string Stats;
        private string sql;
        public SortsWindow()
        {
            sql = "";
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);
        }

        private void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            if (table != null) table.Clear();

            Stats = Stats_Box.SelectedItem.ToString().Substring(37);
           

            switch(Stats.Trim())
            {
                case "Найбільш популярний товар":
                    sql = $"SELECT p.Name,p.Price, SUM(op.Quantity)AS Quant FROM(Parts p INNER JOIN Order_Part op ON p.Part_Id = op.Part_Id) INNER JOIN Orders o ON o.Order_Id = op.Order_Id WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}'  GROUP BY p.Name,p.Price HAVING SUM(op.Quantity) = (SELECT MAX(res) FROM(SELECT SUM(op.Quantity) AS res FROM Order_Part op GROUP BY op.Part_Id)Hello_world )";
                    break;
                case "Виручка":
                    sql = $"SELECT COUNT(o.Order_Id) AS Count_Orders, SUM(op.Quantity) AS Count_Parts, SUM(op.Quantity * p.Price) AS Total FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}'";
                    break;
                case "Середній чек":
                    sql = "SELECT  o.Create_Date, SUM(op.Quantity * p.Price)/SUM(op.Quantity) AS AVG_CHECKFROM FROM (Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id GROUP BY  o.Create_Date";
                    break;
                case "Продані товари":
                    sql = $"SELECT  p.Part_Id, p.Name,p.Price, SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total,o.Create_Date FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}' GROUP BY p.Part_Id,p.Name,p.Price, o.Create_Date  ";
                    break;
                case "Виручка по місяцям":
                    sql = $"SELECT  Format(o.Create_Date,'MM-yy'),  SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id Where Format(o.Create_Date,'MM-yy') BETWEEN Format(CAST('{From_Date.SelectedDate.ToString()}' as date),'MM-yy') AND Format(CAST('{To_Date.SelectedDate.ToString()}' as date),'MM-yy') GROUP BY Format(o.Create_Date, 'MM-yy')";
                    break;
               // case "Витрачена сума клієнтів за певний період":
         //           sql = "Select o.Create_Date, CONCAT(u.Name,' ' ,u.Second_name, ' ', u.Surname) AS Name,CASE 
//WHEN d.Disc IS NULL
//THEN SUM(op.Quantity * p.Price)
//ELSE(SUM(op.Quantity * p.Price) - SUM(op.Quantity * p.Price) * d.Disc / 100)
//END 'TOTAL'
//FROM Users u INNER JOIN Orders o ON u.User_Id = o.User_Id INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id INNER JOIN Parts p ON op.Part_Id = p.Part_Id LEFT JOIN Discounts d ON u.Disc_Id = d.Disc_Id
//Group By o.Create_Date, CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname), d.Disc"
            }
            connection.Open();
          
            adapter = new SqlDataAdapter(sql, connection);
            table = new DataTable();
            adapter.Fill(table);
            Result_Grid.ItemsSource = table.DefaultView;

            connection.Close();
        }
    }
}
