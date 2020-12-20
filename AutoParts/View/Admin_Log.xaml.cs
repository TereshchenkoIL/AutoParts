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
    /// Логика взаимодействия для Admin_Log.xaml
    /// </summary>
    public partial class Admin_Log : Window
    {
        DBManager manager;
        DataTable users;
        public Admin_Log()
        {
            InitializeComponent();
            manager = new DBManager();
            users = manager.Select("SELECT UserName, Password, User_Id FROM Users WHERE IsAdmin = 1").Tables[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = Check();
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
        private int Check()
        {
            foreach (DataRow row in users.Rows)
            {
                if ((string)row["UserName"] == Admin_name.Text && (string)row["Password"] == Admin_pas.Password)
                    return (int)row["User_Id"];
            }
            return -1;
        }
    }
}
