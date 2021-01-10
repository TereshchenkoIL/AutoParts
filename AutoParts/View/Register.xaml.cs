using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private User user;
        private DBManager manager;
        List<string> users;
        public Register()
        {
            InitializeComponent();
            manager = new DBManager();
            users = manager.Select("SELECT UserName FROM Users").Tables[0].AsEnumerable().Select(x => (string)x["UserName"]).ToList() ;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if(first_pas.Password != second_pas.Password)
            {
                MessageBox.Show("Паролі не збігаються \n Спробуйте ще раз");
                return;
            }

            if(users.Contains(UserNameBox.Text))
            {
                MessageBox.Show("Такий username вже існує");
                return;
            }

            if(!Email_Box.Text.Contains("@"))
            {
                MessageBox.Show("Email введений не вірно \n Спробуйте ще раз");
                return;
            }


            user = new User(NameBox.Text,SeconNameBox.Text,SurnameBox.Text, Email_Box.Text, PhoneBox.Text, UserNameBox.Text, first_pas.Password);
            int id = manager.Create_User(user);
            MessageBox.Show("Дякуємо за регістрацію");
            User_Cabinet uc = new User_Cabinet(id);
            uc.Show();
            Close();
        }
    }
}
