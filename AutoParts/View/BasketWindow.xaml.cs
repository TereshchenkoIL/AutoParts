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
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        private Basket basket;
        private DBManager manager;
        private int user;
        public BasketWindow()
        {
            InitializeComponent();
        }
        public BasketWindow(Basket b, int id)
        {
            basket = b;
            InitializeComponent();
            DataContext = this;
            Grid.ItemsSource = basket.Elements;
           
            manager = new DBManager();
            user = id;
            
            
            TotalLabel.Content = basket.SumTotal().ToString();
        }

      
        private void Updated(object sender, DataGridRowEditEndingEventArgs e)
        {
            TotalLabel.Content = basket.SumTotal().ToString();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = Grid.SelectedIndex;
            if (index == -1) return;
            basket.Elements.RemoveAt(index);
        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            manager.AddOrder(user, basket);
            basket.Elements.Clear();
            MessageBox.Show("Операцію виконано успішно");
            Close();
        }
    }
}
