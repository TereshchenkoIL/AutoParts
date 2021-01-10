using AutoParts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для EditDiscount.xaml
    /// </summary>
    public partial class EditDiscount : Window
    {
        
        public EditDiscount()
        {
            InitializeComponent();
            manager = new DBManager();
            Edit = false;
        }
        public EditDiscount(DataRow row)
        {
            InitializeComponent();
            manager = new DBManager();
            Name = (string)row["Discount_Name"];
            Desc = (string)row["Descript"];
            Disc = ((int)row["Disc"]).ToString();
            Edit = true;
            NameBox.IsReadOnly = true;
        }
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }
        public string Desc
        {
            get
            {
                return (string)GetValue(DescProperty);
            }
            set
            {
                SetValue(DescProperty, value);
            }
        }
        public string Disc
        {
            get
            {
                return (string)GetValue(DiscProperty);
            }
            set
            {
                SetValue(DiscProperty, value);
            }
        }
        private DBManager manager;
        private bool Edit;
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EditDiscount), new PropertyMetadata("test"));
        public static readonly DependencyProperty DescProperty =
           DependencyProperty.Register("Desc", typeof(string), typeof(EditDiscount), new PropertyMetadata("test"));
        public static readonly DependencyProperty DiscProperty =
         DependencyProperty.Register("Disc", typeof(string), typeof(EditDiscount), new PropertyMetadata("test"));


        public event PropertyChangedEventHandler PropertyChanged;

        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            int disc = -1;
            bool succes = int.TryParse(Disc, out disc);
            if (!succes) return;
            if (disc == -1) return;
            if (Edit)
            {
                manager.Update_Disc(Name, Desc, disc);
            }
            else 
                manager.Add_Disc(Name, Desc, disc);
            MessageBox.Show("Операцію виконано успішно");
            Close();
        }
    }
}
