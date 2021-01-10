using AutoParts.Model;
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

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для User_Cabinet.xaml
    /// </summary>
    public partial class User_Cabinet : Window
    {
        private DBManager manager;
        private int Id;
        private bool isEdit = false;
        private DataRow user;
        private DataTable orders;
        public User_Cabinet()
        {
            InitializeComponent();
            
            manager = new DBManager();
            user = manager.GetUserInformation(1).Tables[0].Rows[0];
            Name_Box.Text = (string)user["Name"];
            SNameBox.Text = (string)user["Second_name"];
            SurBox.Text = (string)user["Surname"];
            EmailBox.Text = (string)user["Email"];
            PhoneBox.Text = (string)user["Phone"];
            CityBox.Text = (string)user["City"];
            AdressBox.Text = (string)user["Adress"];
            orders = manager.GetUserOrderDetails(1).Tables[0];
            Grid.ItemsSource = orders.DefaultView;

        }
        public User_Cabinet(int id)
        {
            InitializeComponent();
            Id = id;
            manager = new DBManager();
            user = manager.GetUserInformation(id).Tables[0].Rows[0];
            Name_Box.Text = (string)user["Name"];
            SNameBox.Text = (string)user["Second_name"];
            SurBox.Text = (string)user["Surname"];
            EmailBox.Text = (string)user["Email"];
            PhoneBox.Text = (string)user["Phone"];
            CityBox.Text = (string)user["City"];
            AdressBox.Text = (string)user["Adress"];
            orders = manager.GetUserOrderDetails(id).Tables[0];
            if(orders.Rows.Count != 0)
            Grid.ItemsSource = orders.DefaultView;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            
            Order_Detail od = new Order_Detail((int)orders.Rows[index]["Order_Id"]);
            od.ShowDialog();


        }

    
        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!isEdit)
            {
                MessageBox.Show("Тепер ви можете редагувати поля");
                Edit_Label.Text = "Зберігти";
                isEdit = true;
                foreach(var i in MainGrid.Children)
                {
                    if( i is TextBox)
                    {
                        ((TextBox)i).IsReadOnly = false;
                    }
                }
            }
            else
            {
                Edit_Label.Text = "Редагувати";
                user["Name"] = Name_Box.Text;
                user["Second_name"] = SNameBox.Text;
                user["Surname"] = SurBox.Text;
                user["Email"] = EmailBox.Text;
                user["Phone"] = PhoneBox.Text;
                user["City"] = CityBox.Text;
                user["Adress"] = AdressBox.Text;
                manager.UpdateUser(user);
                isEdit = false;
                foreach (var i in MainGrid.Children)
                {
                    if (i is TextBox)
                    {
                        ((TextBox)i).IsReadOnly = true;
                    }
                }
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cars_Selection cs = new Cars_Selection(Id);
            cs.Show();
            Close();
        }
    }
}
