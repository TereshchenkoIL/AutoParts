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

namespace AutoParts.View
{
    /// <summary>
    /// Логика взаимодействия для DoSQL.xaml
    /// </summary>
    public partial class DoSQL : Window
    {
        private DBManager manager;
        public DoSQL()
        {
            InitializeComponent();
            manager = new DBManager();
            Grid.ItemsSource = manager.Select("SELECT * FROM PARTS").Tables[0].DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = QueryText.Text;
            if (sql == "") return;
            Grid.ItemsSource = manager.Select(sql).Tables[0].DefaultView;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Scheme s = new Scheme();
            s.ShowDialog();
        }
    }
}
