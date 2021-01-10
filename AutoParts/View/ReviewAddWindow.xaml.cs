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
    /// Логика взаимодействия для ReviewAddWindow.xaml
    /// </summary>
    public partial class ReviewAddWindow : Window
    {
        private int stars = 5;
        private int User_Id;
        private int Part_Id;
        private DBManager manager;
        public ReviewAddWindow()
        {
            InitializeComponent();
        }
        public ReviewAddWindow(int user, int part)
        {
            InitializeComponent();
            User_Id = user;
            Part_Id = part;
            manager = new DBManager();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            stars = int.Parse(pressed.Content.ToString());
            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            manager.AddRewiev(User_Id,Part_Id,stars,Message.Text);
            MessageBox.Show("Дякуємо за відгук!");
            Close();
        }
    }
}
