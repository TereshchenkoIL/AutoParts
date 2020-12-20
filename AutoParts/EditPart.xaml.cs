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
using AutoParts.Model;

namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для EditPart.xaml
    /// </summary>
    public partial class EditPart : Window
    {
        private DataTable types;
        private DataTable properties;
        private DataTable cars;
        private SqlDataAdapter cars_adapter;
        private SqlDataAdapter type_adapter;
        private SqlDataAdapter Property_adapter;
        private SqlConnection connection;
        private int prop_id;
        private int type_id;
        private bool edit;
        int Id;
        int? Car_Id;
        private DBManager manager;
        public EditPart()
        {
            InitializeComponent();
            edit = false;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);
            cars = new DataTable();
            connection.Open();
            string select_types = "Select * FROM Pr_Types";
            string select_properties = "Select * FROM Properties";
            string select_cars = "SELECT Concat(Mark,' ', Model, ' ', Year) AS Name, Car_Id FROM Cars";
            types = new DataTable();
            properties = new DataTable();
            cars_adapter = new SqlDataAdapter(select_cars, connection);
            cars_adapter.Fill(cars);
            Property_adapter = new SqlDataAdapter(select_properties, connection);
            type_adapter = new SqlDataAdapter(select_types,connection);
            type_adapter.Fill(types);
            Property_adapter.Fill(properties);

            Property_Box.ItemsSource = properties.DefaultView;
            Property_Box.DisplayMemberPath = "Name";
            Property_Box.SelectedValuePath = "Prop_Id";

            Type_Box.ItemsSource = types.DefaultView;
            Type_Box.DisplayMemberPath = "Name";
            Type_Box.SelectedValuePath = "Type_Id";

            Car_Box.ItemsSource = cars.DefaultView;
            Car_Box.DisplayMemberPath = "Name";
            Car_Box.SelectedValuePath = "Car_Id";
            connection.Close();
           
                
        }

        public EditPart(int _id,int? car, decimal _price, int _type, string _name, string _desc, string _prod, int warr )
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);
            cars = new DataTable();
            connection.Open();
            string select_types = "Select * FROM Pr_Types";
            string select_properties = "Select * FROM Properties";
            string select_cars = "SELECT Concat(Mark,' ', Model, ' ', Year) AS Name, Car_Id FROM Cars";
            types = new DataTable();
            properties = new DataTable();
            Property_adapter = new SqlDataAdapter(select_properties, connection);
            type_adapter = new SqlDataAdapter(select_types, connection);
            type_adapter.Fill(types);
            Property_adapter.Fill(properties);

            cars_adapter = new SqlDataAdapter(select_cars, connection);
            cars_adapter.Fill(cars);

            Property_Box.ItemsSource = properties.DefaultView;
            Property_Box.DisplayMemberPath = "Name";
            Property_Box.SelectedValuePath = "Prop_Id";

            Type_Box.ItemsSource = types.DefaultView;
            Type_Box.DisplayMemberPath = "Name";
            Type_Box.SelectedValuePath = "Type_Id";

            Car_Box.ItemsSource = cars.DefaultView;
            Car_Box.DisplayMemberPath = "Name";
            Car_Box.SelectedValuePath = "Car_Id";

            connection.Close();


            edit = true;
            Id = _id;
            Price_Box.Text = _price.ToString();
            Type_Box.SelectedIndex = DisplayType(_type);
            Name_Box.Text = _name;
            Desc_Box.Text = _desc;
            Warrant_box.Text = warr.ToString();
            Car_Id = car;
            Display_Prop(Id);
            Display_Car();

        }

        public EditPart(int id)
        {
            InitializeComponent();
            manager = new DBManager();
            DataRow row = manager.GetParts(id).Tables[0].Rows[0];
            Price_Box.Text = ((decimal)row["Price"]).ToString();
            Name_Box.Text = (string)row["Name"];
            Desc_Box.Text = (string)row["Descript"];
            Warrant_box.Text = ((int)row["Warranty"]).ToString();
            type_id = (int)row["Type_Id"];        
            types = manager.Select("Select * FROM Pr_Types").Tables[0];
            cars = manager.Select("SELECT Concat(Mark,' ', Model, ' ', Year) AS Name, Car_Id FROM Cars").Tables[0];
            Prop_Grid.ItemsSource = manager.GetProperties(id).Tables[0].DefaultView;
            Type_Box.ItemsSource = types.DefaultView;
            Type_Box.DisplayMemberPath = "Name";
            Type_Box.SelectedValuePath = "Type_Id";

            Car_Box.ItemsSource = cars.DefaultView;
            Car_Box.DisplayMemberPath = "Name";
            Car_Box.SelectedValuePath = "Car_Id";         
            Type_Box.SelectedIndex = DisplayType((int)row["Type_Id"]);
            Complete_Button.Visibility =  Visibility.Hidden;
            Cancel.Visibility = Visibility.Hidden;
            Add_Prop.Visibility = Visibility.Hidden;
            AddLabel.Visibility = Visibility.Hidden;
            Value_Box.Visibility = Visibility.Hidden;
            Property_Box.Visibility = Visibility.Hidden;
            CharactLabel.Visibility = Visibility.Hidden;
            ValueLabel.Visibility = Visibility.Hidden;
            Type_Box.IsEnabled = false;
            Car_Box.IsEnabled = false;
            Prop_Grid.Margin = new Thickness(340, 20, 0, 0);
            Prop_Grid.Height = 280;
            if (row["Car_Id"] is System.DBNull)
                return;
            Car_Id = (int?)row["Car_Id"];
            Display_Car();
           


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type_id = (int)Type_Box.SelectedValue;
        }

        public void Display_Prop(int id)
        {

            string sql = $"Select p.Name,CONCAT(pp.value,p.Unit) As Значення  From((Parts pr INNER JOIN Prop_Part pp ON(pr.Part_Id = pp.Part_Id AND pr.Part_Id = { id})) INNER JOIN Properties p ON pp.Prop_Id = p.Prop_Id)";

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();

                adapter.Fill(ds);
                Prop_Grid.ItemsSource = ds.Tables[0].DefaultView;
            connection.Close();
            

        }
        public int DisplayType(int type)
        {
            int res = -1;
            for(int i = 0; i < types.Rows.Count;i++)
            {
                if (types.Rows[i].Field<int>("Type_Id") == type)
                    res = i;
            }
            return res;
        }

        private void Property_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prop_id = (int)Property_Box.SelectedValue;

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("sp_CreateProp_Part", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@prop", SqlDbType.Int, 0, "Prop_Id");
            command.Parameters.Add("@part", SqlDbType.Int, 0, "Part_Id");
            command.Parameters.Add("@value", SqlDbType.NVarChar, 100, "Value");

            command.Parameters["@prop"].Value = prop_id;
            command.Parameters["@part"].Value = Id;
            command.Parameters["@value"].Value = Value_Box.Text;
            SqlParameter parameter = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            parameter.Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            connection.Close();
            Display_Prop(Id);

        }

      

        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!edit)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CreatePart", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@car", SqlDbType.Int, 0, "Car_Id"));
                command.Parameters.Add(new SqlParameter("@price", SqlDbType.Money, 0, "Price"));
                command.Parameters.Add(new SqlParameter("@type_id", SqlDbType.Int, 0, "Type_Id"));
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 350, "Name"));
                command.Parameters.Add(new SqlParameter("@Descript", SqlDbType.NVarChar, 700, "Descript"));
                //command.Parameters.Add(new SqlParameter("@Producer_Name", SqlDbType.NVarChar, 150, "Producer_Name"));
                command.Parameters.Add(new SqlParameter("@warr", SqlDbType.Int, 0, "Warranty"));
                SqlParameter parameter = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;
                if(Car_Id == null)
                   command.Parameters["@car"].Value = DBNull.Value;
                else
                    command.Parameters["@car"].Value = Car_Id;
                command.Parameters["@price"].Value = Decimal.Parse(Price_Box.Text);
                command.Parameters["@type_id"].Value = type_id;
                command.Parameters["@name"].Value =Name_Box.Text;
                command.Parameters["@Descript"].Value = Desc_Box.Text;
                //command.Parameters["@Producer_Name"].Value = null;
                command.Parameters["@warr"].Value = int.Parse(Warrant_box.Text);
                command.ExecuteNonQuery();
                connection.Close();
                Close();
            }
            else
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdatePart", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@car", SqlDbType.Int, 0, "Car_Id"));
                command.Parameters.Add(new SqlParameter("@price", SqlDbType.Money, 0, "Price"));
                command.Parameters.Add(new SqlParameter("@type_id", SqlDbType.Int, 0, "Type_Id"));
                command.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 350, "Name"));
                command.Parameters.Add(new SqlParameter("@Desc", SqlDbType.NVarChar, 700, "Descript"));
                command.Parameters.Add(new SqlParameter("@producer", SqlDbType.NVarChar, 150, "Producer_Name"));
                command.Parameters.Add(new SqlParameter("@warr", SqlDbType.Int, 0, "Warranty"));
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Part_Id"));
                command.Parameters["@car"].Value =Car_Id;
                command.Parameters["@price"].Value = Decimal.Parse(Price_Box.Text);
                command.Parameters["@type_id"].Value = type_id;
                command.Parameters["@name"].Value = Name_Box.Text;
                command.Parameters["@Desc"].Value = Desc_Box.Text;
                command.Parameters["@producer"].Value = DBNull.Value;
                command.Parameters["@warr"].Value = int.Parse(Warrant_box.Text);
                command.Parameters["@id"].Value = Id;
                command.ExecuteNonQuery();
                connection.Close();
                Close();
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CarBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car_Id = (int?) Car_Box.SelectedValue;
        }
        private void Display_Car()
        {
            if(Car_Id != null)
            {
                int index = -1;
                for(int i = 0; i < cars.Rows.Count;i++)
                {
                    if (cars.Rows[i].Field<int>("Car_Id") == Car_Id)
                        Car_Box.SelectedIndex = i;
                }
            }
        }
    }
}