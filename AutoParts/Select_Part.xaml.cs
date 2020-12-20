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

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для Select_Part.xaml
    /// </summary>
    public partial class Select_Part : Window
    {
        private DataTable table;
        private DataTable cars;
        private SqlDataAdapter cars_adapter;
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private  int Car_Id;
        private  int Type_Id;
        List<Brake_Disk> direct;
        List<Brake_Disk> undirect;
        public Select_Part()
        {
            
            InitializeComponent();
          
          

            table = new DataTable();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();

            string select_cars = "SELECT Concat(Mark,' ', Model, ' ', Year) AS Name, Car_Id FROM Cars";

            cars = new DataTable();
            cars_adapter = new SqlDataAdapter(select_cars, connection);

            cars_adapter.Fill(cars); 
           // Grid.ItemsSource = table.DefaultView;
            connection.Close();

            Car_Box.ItemsSource = cars.DefaultView;
            Car_Box.DisplayMemberPath = "Name";
            Car_Box.SelectedValuePath = "Car_Id";

        }

        private void Prepare_DList()
        {
            direct = new List<Brake_Disk>();
            connection.Open();
            string sql = $"SELECT p.Part_Id, p.Name,  PR.Name, OP.Value, CONCAT(C.Mark, ' ', c.Model) AS Car FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id Left OUTER JOIN Cars c ON c.Car_Id = P.Car_Id WHERE p.Car_Id = { Car_Id} AND NOT pr.Name = 'Висота' AND NOT pr.Name = 'Кількість отвірів для закріплення' GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name,CONCAT(C.Mark, ' ', c.Model) Order By p.Part_Id ASC, pr.Name ASC";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.Fill(table);
            connection.Close();

            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Disk br = new Brake_Disk(table.Rows[i].Field<int>("Part_Id"),table.Rows[i].Field<string>("Value"), table.Rows[i+1].Field<string>("Value"),table.Rows[i+2].Field<string>("Value"), table.Rows[i+3].Field<string>("Value"), table.Rows[i].Field<string>("Name"), table.Rows[i].Field<string>("Car"));
                direct.Add(br);
            }
            Grid.AutoGenerateColumns = true;

            Prepare_UList();
        }

        private void Prepare_UList()
        {
            undirect = new List<Brake_Disk>();
            connection.Open();
            string sql = $"SELECT p.Part_Id, p.Name,  PR.Name, OP.Value,  CONCAT(C.Mark, ' ', c.Model) AS Car FROM(Parts p INNER JOIN Prop_Part op ON p.Part_Id = op.Part_Id) INNER JOIN Properties pr ON op.Prop_Id = pr.Prop_Id LEFT OUTER JOIN Cars c ON c.Car_Id = p.Car_Id WHERE p.Type_Id = 2  AND NOT pr.Name = 'Висота' AND NOT pr.Name = 'Кількість отвірів для закріплення' AND NOT p.Car_Id = {Car_Id} GROUP BY p.Part_Id, PR.Name, OP.Value, p.Name, CONCAT(C.Mark, ' ', c.Model) Order By p.Part_Id ASC, pr.Name ASC";
            adapter = new SqlDataAdapter(sql, connection);
            table.Clear();
            adapter.Fill(table);
           

            for (int i = 0; i < table.Rows.Count; i += 4)
            {
                Brake_Disk br = new Brake_Disk(table.Rows[i].Field<int>("Part_Id"), table.Rows[i].Field<string>("Value"), table.Rows[i + 1].Field<string>("Value"), table.Rows[i + 2].Field<string>("Value"), table.Rows[i + 3].Field<string>("Value"), table.Rows[i].Field<string>("Name"), table.Rows[i].Field<string>("Car"));
                AddToUList(br);
            }
            connection.Close();

           var res = direct.Concat(undirect);
            Grid.ItemsSource = res;
        }
        private void AddToUList(Brake_Disk br)
        {
            foreach(var i in direct)
            {
                if(i.ExDleiametr == br.ExDleiametr && (br.CDiametr >= i.CDiametr -1 || br.CDiametr <= i.CDiametr + 1) && (br.Thin >= i.MinThin || br.Thin <= i.Thin +2))
                    undirect.Add(br);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            table.Clear();
            Prepare_DList();
        }

        private void Car_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car_Id = (int) Car_Box.SelectedValue;
        }
    }
}
