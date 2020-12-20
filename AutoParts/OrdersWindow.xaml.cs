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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private DataTable table;
        private SqlDataAdapter adapter;
        private SqlConnection connection;
        private EnumerableRowCollection<DataRow> filtered;
        public bool IsFiltered;
        private bool ASC;
        public OrdersWindow()
        {
            InitializeComponent();
            table = new DataTable();

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string sql = "Select o.Order_Id,SUM(p.Price*OP.Quantity) AS Total,CONCAT(u.Name,' ',u.Second_name,' ',u.Surname) AS FIO, o.Create_Date,o.Curr,o.Create_Time, o.User_Id From((Orders o INNER JOIN Order_Part op ON o.Order_Id = op.Order_Id) INNER JOIN Parts p ON op.Part_Id = p.Part_Id) INNER JOIN Users u on u.User_Id = o.User_Id Group BY o.Order_Id,o.Create_Date,o.Curr,o.Curr,o.Create_Time,u.Name,u.Second_name,u.Surname,o.User_Id";
            adapter = new SqlDataAdapter(sql, connection);
            adapter.DeleteCommand = new SqlCommand("sp_DeleteOrder", connection);
            adapter.DeleteCommand.CommandType = CommandType.StoredProcedure;
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Order_Id"));
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            adapter.Fill(table);
            Grid.ItemsSource = table.DefaultView;

            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            int id = table.Rows[Grid.SelectedIndex].Field<int>("Order_Id");
            table.Rows.RemoveAt(Grid.SelectedIndex);
            adapter.DeleteCommand.Parameters["@id"].Value = id;
            adapter.DeleteCommand.ExecuteNonQuery();
            adapter.Update(table);
            table.AcceptChanges();
            connection.Close();
        }
    

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            EditOrder ed = new EditOrder();
            ed.ShowDialog();
            adapter.Update(table);
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            var row = table.Rows[index];
            EditOrder ed = new EditOrder(row.Field<int>("Order_Id"),row.Field<int>("User_Id"),row.Field<DateTime>("Create_Date"), row.Field<TimeSpan>("Create_Time"), row.Field<string>("Curr"));
            ed.ShowDialog();
            table.Clear();
            adapter.Fill(table);
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Grid.Items.Count; i++)
            {

                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                row.Background = Brushes.White;

            }

            if (IsFiltered)
            {
                DataTable temp = filtered.CopyToDataTable();
                if (AllFields.IsChecked == true)
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<DateTime>("Create_Date").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<string>("Curr").ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<string>("FIO").ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }

                }
                else
                {

                    if (ByDate.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<DateTime>("Create_Date").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                    if (ByCurr.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<string>("Curr").ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                    if (ByUser.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<string>("FIO").ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                }
            }
            else
            {
                DataTable temp = table;
                if (AllFields.IsChecked == true)
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<DateTime>("Create_Date").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<string>("Curr").ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        if (temp.Rows[i].Field<string>("FIO").ToLower().Contains(SearchBox.Text.ToLower()))
                        {
                            var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                            row.Background = Brushes.Green;
                        }
                    }

                }
                else
                {

                    if (ByDate.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<DateTime>("Create_Date").ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                    if (ByCurr.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<string>("Curr").ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                    if (ByUser.IsChecked == true)
                    {
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            if (temp.Rows[i].Field<string>("FIO").ToLower().Contains(SearchBox.Text.ToLower()))
                            {
                                var row = (DataGridRow)Grid.ItemContainerGenerator.ContainerFromIndex(i);
                                row.Background = Brushes.Green;
                            }
                        }
                    }
                }
            }
        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            filtered = table.AsEnumerable();

            IsFiltered = true;

            if (From_Sum.Text != "" && To_Sum.Text != "")
                filtered = filtered.Where(x => x.Field<decimal>("Total") > decimal.Parse(From_Sum.Text) && x.Field<decimal>("Total") < decimal.Parse(To_Sum.Text));
            if (User_box.Text != "")
                filtered = filtered.Where(x => x.Field<string>("FIO") == User_box.Text);
            if (Currbox.Text != "")
                filtered = filtered.Where(x => x.Field<string>("Curr") == Currbox.Text);
            if(From_Date.SelectedDate != null && To_Date.SelectedDate != null)
                filtered = filtered.Where(x => x.Field<DateTime>("Create_Date") >From_Date.SelectedDate && x.Field<DateTime>("Create_Date") < To_Date.SelectedDate);

            Grid.ItemsSource = filtered.CopyToDataTable().DefaultView;
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
                case "Сумі":
                    if (ASC)
                        temp.Sort = "Total ASC";
                    else
                        temp.Sort = "Total DESC";
                    break;
                case "Даті створення":
                    if (ASC)
                        temp.Sort = "Create_Date ASC";
                    else
                        temp.Sort = "Create_Date DESC";
                    break;
                case "Часу створення":
                    if (ASC)
                        temp.Sort = "Create_Time ASC";
                    else
                        temp.Sort = "Create_Time DESC";
                    break;

            }


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

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
            int id = table.Rows[Grid.SelectedIndex].Field<int>("Order_Id");
            Reports r = new Reports(true, id);
            r.ShowDialog();
        }
    }
}