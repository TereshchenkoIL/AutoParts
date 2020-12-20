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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        DBManager manager;
        DataTable users;
        public LogIn()
        {
            InitializeComponent();
            manager = new DBManager();
            users = manager.Select("SELECT UserName, Password, User_Id FROM Users").Tables[0];
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            if (user_name.Text == "" && user_pas.Password == "") return;
            int user_id = Check();
            if(user_id == -1)
            {
                MessageBox.Show("Неправильний пароль чи логін \n Спробуйте ще раз");
                return;
            }

            User_Cabinet uc = new User_Cabinet(user_id);
            uc.Show();
            Close();

        }

        private int Check()
        {
            foreach(DataRow row in users.Rows)
            {
                if ((string)row["UserName"] == user_name.Text && (string)row["Password"] == user_pas.Password)
                    return (int)row["User_Id"];
            }
            return -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
            Close();
        }

        private void Catch(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift) && e.Key == Key.F1)
            {
                Admin_Log admin = new Admin_Log();
                admin.Show();
                this.Close();
            }
        }
    }
}
