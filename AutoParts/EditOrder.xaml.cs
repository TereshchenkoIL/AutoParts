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
    /// Логика взаимодействия для EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private DataTable users;
        private DataTable parts;
        private DataTable order_part;
        private SqlDataAdapter op_adapter;
        private SqlDataAdapter user_adapter;
        private SqlDataAdapter part_adapter;
        private SqlConnection connection;
        private int Id;
        private bool edit;
        private int user_id;
        public EditOrder()
        {
            InitializeComponent();
            edit = false;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string select_users = "Select * FROM Users";
            string select_parts = "Select * FROM Parts";
            string select_op = $"SELECT p.Name,p.Price,op.Quantity FROM Parts p INNER JOIN Order_Part op ON p.Part_Id = op.Part_Id WHERE op.Order_Id ={Id}";
            users = new DataTable();
            parts = new DataTable();
            user_adapter = new SqlDataAdapter(select_users, connection);
            part_adapter = new SqlDataAdapter(select_parts, connection);
            user_adapter.Fill(users);
            part_adapter.Fill(parts);

            User_Box.ItemsSource = users.DefaultView;
            User_Box.DisplayMemberPath = "UserName";
            User_Box.SelectedValuePath = "User_Id";

            Part_Box.ItemsSource = parts.DefaultView;
            Part_Box.DisplayMemberPath = "Name";
            Part_Box.SelectedValuePath = "Part_Id";
            connection.Close();
        }
        public EditOrder(int _id,int _user_id, DateTime _date, TimeSpan _time, string _curr)
        {
            InitializeComponent();
            edit = true;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string select_users = "Select * FROM Users";
            string select_parts = "Select * FROM Parts";
            string select_op = $"SELECT p.Name,p.Price,op.Quantity FROM Parts p INNER JOIN Order_Part op ON p.Part_Id = op.Part_Id WHERE op.Order_Id ={Id}";
            users = new DataTable();
            parts = new DataTable();
            order_part = new DataTable();
            op_adapter = new SqlDataAdapter(select_op, connection);
            user_adapter = new SqlDataAdapter(select_users, connection);
            part_adapter = new SqlDataAdapter(select_parts, connection);
            user_adapter.Fill(users);
            part_adapter.Fill(parts);

            User_Box.ItemsSource = users.DefaultView;
            User_Box.DisplayMemberPath = "UserName";
            User_Box.SelectedValuePath = "User_Id";

            Part_Box.ItemsSource = parts.DefaultView;
            Part_Box.DisplayMemberPath = "Name";
            Part_Box.SelectedValuePath = "Part_Id";
            connection.Close();
            user_id = _user_id;
            Date_picker.SelectedDate = _date;
            Time_Box.Text = _time.ToString();
            Curr_Box.Text = _curr;
            Part_Grid.ItemsSource = order_part.DefaultView;
        }

        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!edit)
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
                command.Parameters["@date"].Value = Date_picker.SelectedDate;
                command.Parameters["@time"].Value = TimeSpan.Parse(Time_Box.Text);
                command.Parameters["@curr"].Value = Curr_Box.Text;
                command.ExecuteNonQuery();         
                connection.Open();
            }
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateOrder", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@user", SqlDbType.Int, 0, "User_Id"));
                command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date, 0, "Create_Date"));
                command.Parameters.Add(new SqlParameter("@time", SqlDbType.Time, 0, "Create_Time"));
                command.Parameters.Add(new SqlParameter("@curr", SqlDbType.VarChar, 1, "Curr"));
               command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
              
                command.Parameters["@user"].Value = user_id;
                command.Parameters["@date"].Value = Date_picker.SelectedDate;
                command.Parameters["@time"].Value = TimeSpan.Parse(Time_Box.Text);
                command.Parameters["@curr"].Value = Curr_Box.Text;
                command.Parameters["@Id"].Value = Id;
                command.ExecuteNonQuery();
                connection.Close();
            }
            Close();
        }

        private void User_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user_id = (int)User_Box.SelectedValue;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int q = int.Parse(Amount_Box.Text);
            int part_id = (int) Part_Box.SelectedValue;
            SqlCommand command = new SqlCommand("sp_CreateOP", connection);
            command.Parameters.Add(new SqlParameter("@order", SqlDbType.Int, 0, "Order_Id"));
            command.Parameters.Add(new SqlParameter("@part", SqlDbType.Int, 0, "Part_Id"));
            command.Parameters.Add(new SqlParameter("@quant", SqlDbType.Int, 0, "Quantity"));
            command.Parameters["@order"].Value = Id;
            command.Parameters["@part"].Value = part_id;
            command.Parameters["@quant"].Value = q;
            command.ExecuteNonQuery();
            connection.Close();

        }
        private void Display_Ref()
        {
            op_adapter.Fill(order_part);
            Part_Grid.ItemsSource = order_part.DefaultView;
        }
    }
}