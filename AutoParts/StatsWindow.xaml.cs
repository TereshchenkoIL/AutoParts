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
using AutoParts.Model;
using System.Windows.Controls.DataVisualization.Charting;

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для SortsWindow.xaml
    /// </summary>
    public partial class SortsWindow : Window
    {
        private DataTable table;
        private string Stats;
        private string sql;
        private DBManager manager;
        private Dictionary<string, decimal> Dict;
        private bool Columns = true;
        public SortsWindow()
        {
            sql = "";
            InitializeComponent();
            manager = new DBManager();
        }

        private void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            if (table != null) table.Clear();

            Stats = Stats_Box.SelectedItem.ToString().Substring(37);


            switch (Stats.Trim())
            {
                case "Найбільш популярний товар":
                    sql = $"SELECT p.Name,p.Price, SUM(op.Quantity)AS Quant " +
                        $"FROM(Parts p INNER JOIN Order_Part op ON p.Part_Id = op.Part_Id) " +
                        $"INNER JOIN Orders o ON o.Order_Id = op.Order_Id" +
                        $" WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  " +
                        $"AND  '{To_Date.SelectedDate.ToString()}'  " +
                        $"GROUP BY p.Name,p.Price HAVING SUM(op.Quantity) = (SELECT MAX(res) FROM(SELECT SUM(op.Quantity) AS res" +
                        $" FROM Order_Part op " +
                        $"GROUP BY op.Part_Id)Hello_world )";
                    Columns = true;
                    break;
                case "Виручка від продажу товару по дням":
                    sql = $"SELECT  Format(o.Create_Date,'MM-yy-dd') As Date, SUM(op.Quantity * p.Price) AS Total " +
                        "FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id)" +
                        "  INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $" WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  " +
                        $"AND  '{To_Date.SelectedDate.ToString()}'  " +
                        $"Group By  Format(o.Create_Date,'MM-yy-dd')";
                    Columns = true;
                    break;
                case "Виручка":
                    sql = $"SELECT COUNT(Orders) As 'Кількість заказів', SUM(Count_Parts) AS 'Кількість деталей', Sum(Total) AS 'Загальна сума' " +
                        $"FROM( " +
                        $"SELECT COUNT(o.Order_Id) AS Orders, SUM(op.Quantity) AS Count_Parts, SUM(op.Quantity * p.Price) AS Total " +
                        $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}' " +
                        $"Group By o.Order_Id) Temp";
                    Columns = true;
                    break;
                case "Середній чек":
                    sql = "SELECT  Format(o.Create_Date,'MM-yy-dd') As Date, SUM(op.Quantity * p.Price)/SUM(op.Quantity) AS 'Середній  чек' " +
                        "FROM (Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        "INNER JOIN Parts p ON op.Part_Id = p.Part_Id  " +
                        $"Where o.Create_Date BETWEEN  '{From_Date.SelectedDate.ToString()}' AND  '{To_Date.SelectedDate.ToString()}' " +
                        "GROUP BY  Format(o.Create_Date,'MM-yy-dd')";
                    Columns = true;
                    break;
                case "Продані товари":
                    sql = $"SELECT  p.Part_Id, p.Name,p.Price, SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total,o.Create_Date " +
                        $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}'" +
                        $" GROUP BY p.Part_Id,p.Name,p.Price, o.Create_Date  ";
                    Columns = true;
                    break;
                case "Виручка по місяцям":
                    sql = $"SELECT  Format(o.Create_Date,'MM-yy') As Date,  SUM(op.Quantity) As Quant, SUM(op.Quantity*p.Price) AS Total " +
                        $"FROM(Orders o INNER JOIN  Order_Part op ON o.Order_Id = op.Order_Id) " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"Where o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}' " +
                        $" AND '{To_Date.SelectedDate.ToString()}' " +
                        $" GROUP BY Format(o.Create_Date, 'MM-yy')";
                    Columns = true;
                    break;
                case "Витрачена сума клієнтів за певний період":
                    sql = $"Select  CONCAT(u.Name,' ' ,u.Second_name, ' ', u.Surname) AS Name,  " +
                        $"CASE WHEN d.Disc IS NULL THEN SUM(op.Quantity * p.Price) " +
                        $"ELSE(SUM(op.Quantity * p.Price) - SUM(op.Quantity * p.Price) * d.Disc / 100) " +
                        $"END 'TOTAL' " +
                        $"FROM Users u INNER JOIN Orders o ON u.User_Id = o.User_Id " +
                        $"INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id INNER JOIN Parts p ON op.Part_Id = p.Part_Id " +
                        $"LEFT JOIN Discounts d ON u.Discount_Name = d.Discount_Name " +
                        $"WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}' " +
                        $"Group By  CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname), d.Disc";
                    Columns = true;
                    break;

                case "Кількість відгуків по певному товару":
                    sql = "SELECT p.Name, COUNT(r.Response_Id) AS COUNT" +
                        " FROM PARTS p INNER JOIN Responses r ON P.Part_Id = r.Part_Id" +
                        " GROUP BY p.Name";
                    Columns = true;
                    break;
                case "Найкрупніший покупець":
                    sql = $"Select Name, Total From( Select o.Create_Date AS Date, CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname) AS Name, " +
                        $"SUM(op.Quantity * p.Price) AS Total " +
                        $"FROM Users u INNER JOIN Orders o ON u.User_Id = o.User_Id " +
                        $"INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id  " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id LEFT JOIN Discounts d ON u.Discount_Name = d.Discount_Name " +
                        $"WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}' " +
                        $"Group By o.Create_Date, CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname)) " +
                        $" AS Temp " +
                        $"Where Total = (Select Max(Total) from " +
                        $"(Select o.Create_Date AS Date, CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname) AS Name, " +
                        $"SUM(op.Quantity * p.Price) AS Total " +
                        $"FROM Users u INNER JOIN Orders o ON u.User_Id = o.User_Id " +
                        $"INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id " +
                        $"INNER JOIN Parts p ON op.Part_Id = p.Part_Id LEFT JOIN Discounts d ON u.Discount_Name = d.Discount_Name " +
                        $"WHERE o.Create_Date BETWEEN '{From_Date.SelectedDate.ToString()}'  AND  '{To_Date.SelectedDate.ToString()}' " +
                        $"Group By o.Create_Date, CONCAT(u.Name, ' ', u.Second_name, ' ', u.Surname) ) As tempsub)";
                    Columns = true;
                    break;
                case "Частка типів":
                    sql = "SELECT t.Name, (CAST(COUNT(t.Name) AS DECIMAL(4, 2)) / CAST((SELECT COUNT(p2.PART_Id) FROM Parts p2) AS DECIMAL(4,2))*100) AS Perc" +
                        " FROM Parts p INNER JOIN Pr_Types t ON P.Type_Id = t.Type_Id " +
                        "GROUP BY t.Name";
                    Columns = false;
                    break;
            }
            
            table = manager.Select(sql).Tables[0];
            Dict = new Dictionary<string, decimal>();
            switch (Stats.Trim())
            {

                case "Середній чек":
                  foreach(DataRow row in table.Rows)
                    {
                       Dict.Add(((string)row["Date"]).ToString(),(decimal)row["Середній  чек"]);
                    }
                    break;
                case "Продані товари":
                   
                    break;
                case "Виручка по місяцям":
                    foreach (DataRow row in table.Rows)
                    {
                        Dict.Add((string)row["Date"], (decimal)row["Total"]);
                    }

                    break;
                case "Витрачена сума клієнтів за певний період":
                    foreach (DataRow row in table.Rows)
                    {
                        Dict.Add((string)row["Name"], (decimal)row["Total"]);
                    }
                    break;
                case "Виручка від продажу товару по дням":
                    foreach (DataRow row in table.Rows)
                    {
                        Dict.Add((string)row["Date"], (decimal)row["Total"]);
                    }
                    break;
                case "Кількість відгуків по певному товару":
                    foreach (DataRow row in table.Rows)
                    {
                        Dict.Add((string)row["Name"], (int)row["Count"]);
                    }
                    break;
                case "Частка типів":
                    foreach (DataRow row in table.Rows)
                    {
                        Dict.Add((string)row["Name"], (decimal)row["Perc"]);
                    }
                    break;
            }

            if (Columns)
            {
                ((ColumnSeries)Chart.Series[0]).Visibility = Visibility.Visible;
                ((PieSeries)Chart.Series[1]).ItemsSource = null;
                ((ColumnSeries)Chart.Series[0]).ItemsSource = Dict;
              
            }
            else
            {
                ((PieSeries)Chart.Series[1]).ItemsSource = Dict;
                ((ColumnSeries)Chart.Series[0]).ItemsSource = null;
                ((ColumnSeries)Chart.Series[0]).Visibility = Visibility.Hidden;
            }
            
            Result_Grid.ItemsSource = table.DefaultView;

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Reports r;
            switch (Stats.Trim())
            {

                case "Середній чек":
                    r = new Reports((DateTime)From_Date.SelectedDate, (DateTime)To_Date.SelectedDate, MyReportEnum.AverageCheck);
                    r.ShowDialog();
                    break;
                case "Продані товари":
                    r = new Reports((DateTime)From_Date.SelectedDate, (DateTime)To_Date.SelectedDate, MyReportEnum.Sold_Parts);
                    r.ShowDialog();
                    break;
                case "Виручка по місяцям":
                    r = new Reports((DateTime)From_Date.SelectedDate, (DateTime)To_Date.SelectedDate, MyReportEnum.ProfitPerMonth);
                    r.ShowDialog();
                    break;

                case "Частка типів":
                    r = new Reports(DateTime.Now, DateTime.Now, MyReportEnum.Types);
                    r.ShowDialog();
                    break;
                case "Виручка":
                    r = new Reports((DateTime)From_Date.SelectedDate, (DateTime)To_Date.SelectedDate, MyReportEnum.Profit);
                    r.ShowDialog();
                    break;
                case "Виручка від продажу товару по дням":
                    r = new Reports((DateTime)From_Date.SelectedDate, (DateTime)To_Date.SelectedDate, MyReportEnum.ProfitPerDay);
                    r.ShowDialog();
                    break;
            }


     
           
        }
    }
}
