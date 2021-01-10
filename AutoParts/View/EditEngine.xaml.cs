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
    /// Логика взаимодействия для EditEngine.xaml
    /// </summary>
    public partial class EditEngine : Window
    {
        DBManager manager;
        private int Id;
        public EditEngine()
        {
            InitializeComponent();
            manager = new DBManager();
            Edit = false;

        }
        public EditEngine(int id)
        {
            InitializeComponent();
            manager = new DBManager();
            DataRow row = manager.Select($"SELECT * FROM Engines WHERE Engine_Id = {id}").Tables[0].Rows[0];
            Edit = true;
            Id = id;
            Name = (string)row["Name"];
            Power = ((int)row["Power"]).ToString(); ;
            Volume = ((double)row["Volume"]).ToString();
            Type = (string)row["Type"];


        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Edit)
                manager.Add_Engine(Name, int.Parse(Power), double.Parse(Volume), Type);
            else
                manager.Update_Engine(Id, Name, int.Parse(Power), double.Parse(Volume), Type);
            MessageBox.Show("Операцію виконано успішно");
            Close();
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
        public string Power
        {
            get
            {
                return (string)GetValue(PowerProperty);
            }
            set
            {
                SetValue(PowerProperty, value);
            }
        }
        public string Volume
        {
            get
            {
                return (string)GetValue(VolumeProperty);
            }
            set
            {
                SetValue(VolumeProperty, value);
            }
        }
        public string Type
        {
            get
            {
                return (string)GetValue(TypeProperty);
            }
            set
            {
                SetValue(TypeProperty, value);
            }
        }

        private bool Edit;
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(EditEngine), new PropertyMetadata("test"));
        public static readonly DependencyProperty PowerProperty =
           DependencyProperty.Register("Power", typeof(string), typeof(EditEngine), new PropertyMetadata("test"));
        public static readonly DependencyProperty VolumeProperty =
         DependencyProperty.Register("Volume", typeof(string), typeof(EditEngine), new PropertyMetadata("test"));
        public static readonly DependencyProperty TypeProperty =
        DependencyProperty.Register("Type", typeof(string), typeof(EditEngine), new PropertyMetadata("test"));


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
