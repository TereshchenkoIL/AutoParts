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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    /// 
    public partial class EditUser : Window
    {
        private DataTable discounts;
        private SqlDataAdapter discount_adapter;
        private SqlConnection connection;
        private int prop_id;
        private int type_id;
        private bool edit;
        int Id;
        public EditUser()
        {
            InitializeComponent();
            edit = false;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);

            connection.Open();
            string select_disc = "Select * FROM Discounts";
            
            discounts = new DataTable();
          
            
            discount_adapter = new SqlDataAdapter(select_disc, connection);
            discount_adapter.Fill(discounts);
     

            Discount_Box.ItemsSource = discounts.DefaultView;
            Discount_Box.DisplayMemberPath = "Name";
            Discount_Box.SelectedValuePath = "Prop_Id";

          
            connection.Close();
        }

        public EditUser(int _id,string _name, string _second, string _sur, string _email, string _phone, string _usern, string _pass, string _city, string _adress, int? _disc)
        {
            InitializeComponent();
            edit = true;
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Autoparts"].ConnectionString);
            Name_Box.Text = _name;
            Second_Box.Text = _second;
            Surname_Box.Text = _sur;
            Email_Box.Text = _email;
            Phone_Box.Text = _phone;
            UserName_Box.Text = _usern;
            Password_Box.Text = _pass;
            City_Box.Text = _city;
            Adress_Box.Text = _adress;
            Discount_Box.Text = _disc.ToString();
            connection.Open();
            string select_disc = "Select * FROM Discounts";

            discounts = new DataTable();

            Id = _id;

            discount_adapter = new SqlDataAdapter(select_disc, connection);
            discount_adapter.Fill(discounts);


            Discount_Box.ItemsSource = discounts.DefaultView;
            Discount_Box.DisplayMemberPath = "Name";
            Discount_Box.SelectedValuePath = "Prop_Id";


            connection.Close();
        }
        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!edit)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CreateUser",connection);
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
                command.Parameters["@name"].Value = Name_Box.Text;
                command.Parameters["@surname"].Value = Surname_Box.Text;
                command.Parameters["@second"].Value = Second_Box.Text;
                command.Parameters["@email"].Value = Email_Box.Text;
                command.Parameters["@phone"].Value = Phone_Box.Text;
                command.Parameters["@username"].Value = UserName_Box.Text;
                command.Parameters["@password"].Value = Password_Box.Text;
                command.Parameters["@city"].Value = City_Box.Text;
                command.Parameters["@disc"].Value = DBNull.Value;
                command.Parameters["@isAdmin"].Value = false;
                command.Parameters["@adress"].Value = Adress_Box.Text;
                command.ExecuteNonQuery();
                connection.Close();
                Close();
            }
            else
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
   
                command.Parameters["@name"].Value = Name_Box.Text;
                command.Parameters["@surname"].Value = Surname_Box.Text;
                command.Parameters["@second"].Value = Second_Box.Text;
                command.Parameters["@email"].Value = Email_Box.Text;
                command.Parameters["@phone"].Value = Phone_Box.Text;
                command.Parameters["@username"].Value = UserName_Box.Text;
                command.Parameters["@password"].Value = Password_Box.Text;
                command.Parameters["@city"].Value = City_Box.Text;
                command.Parameters["@disc"].Value = DBNull.Value;
                command.Parameters["@isAdmin"].Value = false;
                command.Parameters["@adress"].Value = Adress_Box.Text;
                command.Parameters["@Id"].Value = Id;
                command.ExecuteNonQuery();
                connection.Close();
                Close();

            }

        }
    }
}
