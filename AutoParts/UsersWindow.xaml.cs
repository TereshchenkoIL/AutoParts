﻿using System;
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
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        private DataTable table;
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private EnumerableRowCollection<DataRow> filtered;
        public bool IsFiltered;
        private bool ASC;
        public UsersWindow()
        {
            InitializeComponent();

            table = new DataTable();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string sql = "SELECT u.User_Id, u.Name,u.Second_name,u.Surname, u.Email, u.Phone, u.UserName, u.City, u.Adress, SUM(p.Price * OP.Quantity) AS Bill,  u.Password, u.Discount_Name" +
                " From((Users u Left JOIN Orders o ON u.User_Id = o.User_Id)" +
                " Left JOIN Order_Part op ON o.Order_Id = op.Order_Id AND o.User_Id = u.User_Id)" +
                " Left JOIN Parts p ON op.Part_Id = p.Part_Id" +
                " Group By u.User_Id,u.Name,u.Second_name,u.Surname, u.Email, u.Phone, u.UserName, u.City, u.Adress, u.Password,u.Discount_Name ";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.DeleteCommand = new SqlCommand("sp_DeleteUser", connection);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "User_Id"));
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;

            connection.Close();
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;

            if (From_Sum.Text != "" && To_Sum.Text != "")
                filtered = filtered.Where(x => x.Field<decimal?>("Bill") > decimal.Parse(From_Sum.Text) && x.Field<decimal>("Bill") < decimal.Parse(To_Sum.Text));
            if (Name_box.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Name") == Name_box.Text);
            if (Phonebox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Phone") == Phonebox.Text);
            if (CityBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("City") == CityBox.Text);
            if (AdresBox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Adress") == AdresBox.Text);
            if (filtered.Count() != 0)
                Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
            else
                MessageBox.Show("Відповідного користувача не знайшлося");
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditUser ed = new EditUser();
            ed.ShowDialog();
            table.Clear();
            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;
            IsFiltered = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();

            int id = -1; 
            if(!IsFiltered)
                id = table.Rows[Grid.SelectedIndex].Field<int>("User_Id");
            else
                id = filtered.CopyToDataTable().Rows[Grid.SelectedIndex].Field<int>("User_Id");
            if (id == -1) return;

            IsFiltered = false;
            adapter.DeleteCommand.Parameters["@id"].Value = id;
            adapter.DeleteCommand.ExecuteNonQuery();
            table.Clear();
            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;
            connection.Close();
        
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            DataRow row;
            if (!IsFiltered)
                row = table.Rows[index];
            else
                row = filtered.ElementAt(index);
            EditUser eu = new EditUser(row.Field<int>("User_Id"),row.Field<string>("Name"), row.Field<string>("Second_name"), row.Field<string>("Surname"), row.Field<string>("Email"), row.Field<string>("Phone"), row.Field<string>("UserName"), row.Field<string>("Password"), row.Field<string>("City"), row.Field<string>("Adress"), row.Field<string>("Discount_Name") ?? "" );
            eu.ShowDialog();
            table.Clear();
            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;
            IsFiltered = false;

        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Grid.Items.Count; i++)
            {

                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                row.Background = Brushes.White;

            }
            DataTable temp;
            if (IsFiltered)
                temp = filtered.CopyToDataTable();
            else
                 temp = table;

            if (AllFields.IsChecked == true)
            { 
                    Paint(temp, "Name");                
                    Paint(temp, "Surname");              
                    Paint(temp, "City");      
                    Paint(temp, "Adress");
                    Paint(temp, "Phone");
            }
            else
            {

                if (ByName.IsChecked == true)
                    Paint(temp, "Name");                 
                if (BySur.IsChecked == true)
                    Paint(temp, "Surname");                 
                if (ByCity.IsChecked == true)
                    Paint(temp, "City");
                if (ByAdress.IsChecked == true)
                    Paint(temp, "Adress");
                if (ByPhone.IsChecked == true)
                    Paint(temp, "Phone");
            }
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string field = Sort.SelectedValue.ToString().Substring(37).Trim();
            DataView temp;


            if (IsFiltered)
            {
                temp = filtered.CopyToDataTable().DefaultView;
            }
            else
                temp = table.DefaultView;

            switch (field)
            {
                case "По потраченій сумі":
                    if (ASC)
                        temp.Sort = "Bill ASC";
                    else
                        temp.Sort = "Bill DESC";
                    break;
                case "По місту":
                    if (ASC)
                        temp.Sort = "City ASC";
                    else
                        temp.Sort = "City DESC";
                    break;
                case "По призвіщу":
                    if (ASC)
                        temp.Sort = "Surname ASC";
                    else
                        temp.Sort = "Surname DESC";
                    break;

            }

            if (IsFiltered)
            {
                filtered = temp.ToTable().AsEnumerable();
            }
            else
                table = temp.ToTable();
            Grid.ItemsSource = temp;
        }
        private void ASC_Click(object sender, RoutedEventArgs e)
        {
            ASC = true;
            Asc.BorderBrush = Brushes.Black;
            Dsc.BorderBrush = Brushes.Transparent;
        }

        private void Dsc_Click(object sender, RoutedEventArgs e)
        {
            ASC = false;
            Asc.BorderBrush = Brushes.Transparent;
            Dsc.BorderBrush = Brushes.Black;
        }

        public void Paint(DataTable temp,string column)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i].Field<string>(column).ToLower().Contains(SearchBox.Text.ToLower()))
                {
                    var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                    row.Background = Brushes.Purple;
                }
            }
        }
    }
}
