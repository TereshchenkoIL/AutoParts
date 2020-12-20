using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AutoParts
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PartsWindow pr = new PartsWindow();
            pr.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrdersWindow ow = new OrdersWindow();
            ow.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UsersWindow uw = new UsersWindow();
            uw.ShowDialog();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SortsWindow st = new SortsWindow();
            st.ShowDialog();
       
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Select_Part sp = new Select_Part();
            sp.ShowDialog();
        }
    }
}
