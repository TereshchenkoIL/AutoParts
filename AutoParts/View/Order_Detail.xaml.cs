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
using AutoParts.Model;

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для Order_Detail.xaml
    /// </summary>
    public partial class Order_Detail : Window
    {
        private int Id;
        private DataRow order;
        DBManager manager;
        public Order_Detail(int id)
        {
            InitializeComponent();
            manager = new DBManager();
            Id = id;
            order = manager.GetOrderInformation(id).Tables[0].Rows[0];
            UserBox.Text = (string)order["Name"] + " " + (string)order["Second_name"] + " " + (string)order["Surname"];
            Time_Box.Text = ((TimeSpan)order["Create_Time"]).ToString();
            Date_picker.SelectedDate = (DateTime)order["Create_Date"];
            Curr_Box.Text = (string)order["Curr"];
            Part_Grid.ItemsSource = manager.GetPartInOrder(id).Tables[0].DefaultView;
        }

        private void Report_Button_Click(object sender, RoutedEventArgs e)
        {
           
            Reports r = new Reports(true, Id);
            r.ShowDialog();
        }
    }
}
