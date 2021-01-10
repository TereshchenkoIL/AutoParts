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
    /// Логика взаимодействия для EditProducer.xaml
    /// </summary>
    public partial class EditProducer : Window
    {
        public string Name
        { get
            {
                return (string)GetValue(NameProperty);
            }
            set {
                SetValue(NameProperty, value);
            }
        }
        public string Desc {
            get
            {
                return (string)GetValue(DescProperty);
            }
            set {
                SetValue(DescProperty, value);
            }
        }
        public string Year
        {
            get
            {
                return (string)GetValue(YearProperty);
            }
            set
            {
                SetValue(YearProperty, value);
            }
        }
        private DBManager manager;
        private bool Edit;
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EditProducer), new PropertyMetadata("test"));
        public static readonly DependencyProperty DescProperty =
           DependencyProperty.Register("Desc", typeof(string), typeof(EditProducer), new PropertyMetadata("test"));
        public static readonly DependencyProperty YearProperty =
         DependencyProperty.Register("Year", typeof(string), typeof(EditProducer), new PropertyMetadata("test"));


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public EditProducer()
        {
          
            InitializeComponent();
            Edit = false;
            DataContext = this;
            manager = new DBManager();
          

        }
        public EditProducer(string name)
        {
            Edit = true;
            Name = name;
            InitializeComponent();
            manager = new DBManager();
            DataRow row = manager.Select($"SELECT * FROM Producers WHERE Producer_Name = '{name}'").Tables[0].Rows[0];
            Desc = (string)row["Descript"];
            Year = ((int)row["Year"]).ToString();
            NameBox.IsReadOnly = true;

        }

        private void Complete_Button_Click(object sender, RoutedEventArgs e)
        {
            int year;
            bool yearisnum = int.TryParse(Year,out year);
            if (!yearisnum) return;

            if (Edit)
                manager.Update_Producer(Name, Desc, year);
            else
                manager.Add_Producer(Name, Desc, year);

            MessageBox.Show("Операцію виконано успішно");
            Close();
        }
    }
}
